using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListViewMAUI
{
    public class Feedback : INotifyPropertyChanged
    {
        private int qNo;
        private string question;
        private string answer;

        public int QNo 
        {
            get { return qNo; }
            set
            {
                qNo = value;
                OnPropertyChanged("QNo");
            }
        }
        public string Question 
        { 
            get
            {
                return question;
            }
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }
        public string Answer 
        {
            get { return answer; }
            set
            {
                answer = value;
                OnPropertyChanged("Answer");
            }
        }
        public ObservableCollection<AnswerModel> Answers { get; set; }

        public bool IsDetailedFeedback
        {
            get
            {
                if (Answers == null)
                    return true;

                if (Answers.Count > 1)
                    return false;

                return false;
            }
        }

        private string? selectedValue;
        public string? SelectedValue
        {
            get { return selectedValue; }
            set
            {
                selectedValue = value;
                OnPropertyChanged("SelectedValue");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class AnswerModel : INotifyPropertyChanged
    {
        private string answer;
        public string Answer
        {
            get { return answer; }
            set { answer = value; OnPropertyChanged("Answer"); }
        }

        private bool? isChecked;
        public bool? IsChecked
        {
            get { return isChecked; }
            set
            { 
                isChecked = value; OnPropertyChanged("IsChecked");                
            }
        }

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }

    public class ResponseModel
    {
        public string QNO { get; set; }
        public List<Response> ResponseList { get; set; }
    }
    public class Response
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}