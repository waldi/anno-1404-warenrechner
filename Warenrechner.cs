using System;
using System.Windows.Forms;

namespace Anno1404Warenrechner
{
    public partial class Warenrechner : Form
    {
        Timer periodicCheckTimer = new Timer();
        public Warenrechner()
        {
            InitializeComponent();

            this.periodicCheckTimer.Tick += PeriodicCheckTimer_Tick;
            this.labelError.Text = "";
        }

        private void PeriodicCheckTimer_Tick(object sender, EventArgs e)
        {
            this.calcUpdateNeedsUi();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void RenderNeeds(Needs? needs)
        {
            this.labelFish.Text = needs.HasValue ? this.FormatDouble(needs.Value.Fish) : "?";
            this.labelSpices.Text = needs.HasValue ? this.FormatDouble(needs.Value.Spices) : "?";
            this.labelBread.Text = needs.HasValue ? this.FormatDouble(needs.Value.Bread) : "?";
            this.labelMeat.Text = needs.HasValue ? this.FormatDouble(needs.Value.Meat) : "?";
            this.labelMost.Text = needs.HasValue ? this.FormatDouble(needs.Value.Most) : "?";
            this.labelBeer.Text = needs.HasValue ? this.FormatDouble(needs.Value.Beer) : "?";
            this.labelWine.Text = needs.HasValue ? this.FormatDouble(needs.Value.Wine) : "?";
            this.labelGarments.Text = needs.HasValue ? this.FormatDouble(needs.Value.Garments) : "?";
            this.labelJerkins.Text = needs.HasValue ? this.FormatDouble(needs.Value.Jerkins) : "?";
            this.labelFurCoats.Text = needs.HasValue ? this.FormatDouble(needs.Value.FurCoats) : "?";
            this.labelRobes.Text = needs.HasValue ? this.FormatDouble(needs.Value.Robes) : "?";
            this.labelBooks.Text = needs.HasValue ? this.FormatDouble(needs.Value.Books) : "?";
            this.labelCandleSticks.Text = needs.HasValue ? this.FormatDouble(needs.Value.CandleSticks) : "?";
            this.labelGlasses.Text = needs.HasValue ? this.FormatDouble(needs.Value.Glasses) : "?";

            this.labelDates.Text = needs.HasValue ? this.FormatDouble(needs.Value.Dates) : "?";
            this.labelMilk.Text = needs.HasValue ? this.FormatDouble(needs.Value.Milk) : "?";
            this.labelCarpets.Text = needs.HasValue ? this.FormatDouble(needs.Value.Carpets) : "?";
            this.labelCoffee.Text = needs.HasValue ? this.FormatDouble(needs.Value.Coffee) : "?";
            this.labelPearNecklaces.Text = needs.HasValue ? this.FormatDouble(needs.Value.PearNecklaces) : "?";
            this.labelParfum.Text = needs.HasValue ? this.FormatDouble(needs.Value.Parfum) : "?";
            this.labelMarzipan.Text = needs.HasValue ? this.FormatDouble(needs.Value.Marzipan) : "?";
        }

        private string FormatDouble(double number)
        {
            return string.Format("{0:N2}", number);
        }

        private void buttonLoadNeeds_Click(object sender, EventArgs eventArgs)
        {
            this.calcUpdateNeedsUi();
        }

        private void calcUpdateNeedsUi()
        {
            try
            {
                var population = PopulationReader.ReadPopulation(this.textBoxProcessName.Text);
                var needs = NeedsCalculator.CalculateNeeds(population);

                this.RenderNeeds(needs);
                this.labelError.Text = "";
            }
            catch (Exception exception)
            {
                this.RenderNeeds(null);

                this.labelError.Text = "Failed to load data.";
            }
        }

        private void initStartTimer()
        {
            int interval = 0;
            try
            {
                interval = Convert.ToInt32(textBoxPeriodicCheckInterval.Text) * 1000;
            }
            catch (Exception exception)
            {
                this.labelError.Text = "Invalid interval.";
                return;
            }

            if (interval > 0)
            {
                this.periodicCheckTimer.Stop();
                this.periodicCheckTimer.Interval = interval;
                this.periodicCheckTimer.Start();
            }
        }

        private void checkBoxPeriodicCheck_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                this.textBoxPeriodicCheckInterval.Enabled = true;
                this.initStartTimer();
                this.calcUpdateNeedsUi();
            }
            else
            {
                this.textBoxPeriodicCheckInterval.Enabled = false;
                this.periodicCheckTimer.Stop();
            }
        }

        private void textBoxPeriodicCheckInterval_TextChanged(object sender, EventArgs e)
        {
            this.initStartTimer();
            this.calcUpdateNeedsUi();
        }

        private void textBoxPeriodicCheckInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Cancel input if it is not a digit
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
