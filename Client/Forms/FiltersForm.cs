using System;
using ABSoftware.UI;
using System.Windows.Forms;

namespace Client
{
    public partial class FiltersForm : DraggableForm
    {
        public FiltersForm() : this(DEFAULT_DATA) { }

        public FiltersForm(FilterData dataToLoad)
        {
            InitializeComponent();

            this.MatchWordCB.Checked = dataToLoad.MatchWholeWord;
            this.ShowCompletedCB.Checked = dataToLoad.ShowCompletedTasks;
            this.ShowOutstandingCB.Checked = dataToLoad.ShowOutstandingTasks;
            this.SearchString.Text = dataToLoad.SearchString;
        }

        public readonly static FilterData DEFAULT_DATA = new FilterData() { MatchWholeWord = false, SearchString = string.Empty, ShowCompletedTasks = true, ShowOutstandingTasks = true };
        public FilterData Data { get; private set; }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Data = new FilterData()
            {
                MatchWholeWord = MatchWordCB.Checked,
                SearchString = (SearchString.Text.Length == 0 ? string.Empty : SearchString.Text),
                ShowCompletedTasks = ShowCompletedCB.Checked,
                ShowOutstandingTasks = ShowOutstandingCB.Checked
            };
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private void ResetFiltersButton_Click(object sender, EventArgs e)
        {
            this.MatchWordCB.Checked = false;
            this.ShowCompletedCB.Checked = true;
            this.ShowOutstandingCB.Checked = true;

            this.SearchString.Text = string.Empty;
        }
    }

    public struct FilterData
    {
        public string SearchString;
        public bool MatchWholeWord;

        public bool ShowCompletedTasks;
        public bool ShowOutstandingTasks;
    }
}
