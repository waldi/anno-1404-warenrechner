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
            periodicCheckTimer.Interval = 60000;
            periodicCheckTimer.Tick += PeriodicCheckTimer_Tick;

            labelError.Text = "";
            labelError.ForeColor = System.Drawing.Color.Red;
        }

        private void PeriodicCheckTimer_Tick(object sender, EventArgs e)
        {
            buttonLoadNeeds.PerformClick();
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
            try
            {
                var population = PopulationReader.ReadPopulation(this.textBoxProcessName.Text);
                var needs = NeedsCalculator.CalculateNeeds(population);

                this.RenderNeeds(needs);
                labelError.Text = "";
            }
            catch (Exception exception)
            {
                this.RenderNeeds(null);

                labelError.Text = "Failed to load data.";
            }
        }

        private void checkBoxPeriodicCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                periodicCheckTimer.Start();
                buttonLoadNeeds.PerformClick();
            }
            else
            {
                periodicCheckTimer.Stop();
            }
        }
    }
}
