using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListViewMAUI
{
    public class FeedbackViewModel : INotifyPropertyChanged
    {
        private int responseCount;
        private ObservableCollection<Feedback> feedbacks;
        private ObservableCollection<ResponseModel> responses;
        public ObservableCollection<Feedback> Feedbacks 
        { 
            get
            {
                return feedbacks;
            }
            set
            {
                feedbacks = value;
                OnPropertyChanged("Feedbacks");
            }
        }

        public ObservableCollection<ResponseModel> Responses
        {
            get
            {
                return responses;
            }
            set
            {
                responses = value;
                OnPropertyChanged("Responses");
            }
        }

        public Command SubmitCommand { get; set; }

        public FeedbackViewModel()
        {
            Feedbacks = new ObservableCollection<Feedback>();
            Responses   = new ObservableCollection<ResponseModel>();
            GenerateFeedbacks();
            SubmitCommand = new Command(OnSubmit);
        }

        private void ResetFeedbacks()
        {
            foreach (var feedback in Feedbacks)
            {
                feedback.Answer = string.Empty;  
                feedback.SelectedValue = null;
                if (feedback.Answers != null)
                {
                    foreach (var answer in feedback.Answers)
                    {
                        answer.IsChecked = false;
                    }
                }
            }
        }
        private void OnSubmit(object obj)
        { 
            var responseList = Feedbacks.Select(feedback =>
            {
                var selectedAnswer = feedback.Answers?.FirstOrDefault(o => o.IsChecked != null)?.Answer ?? feedback.Answer;

                return new Response
                {
                    Question = feedback.Question,
                    Answer = selectedAnswer,
                };
            }).ToList();

            var response = new ResponseModel
            {
                QNO = responseCount++.ToString(),
                ResponseList = responseList
            };

            Responses.Add(response);  

            ResetFeedbacks();
        }        

        private void GenerateFeedbacks()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Feedbacks.Add(new Feedback
                {
                    QNo = i+1,
                    Question = Questions[i],
                    Answer = Answers[i],                                            
                });
            }
            for (int i = 0; i < Feedbacks.Count; i++)
            {
                var feedback = Feedbacks[i];
                if(feedback.Answer.Contains("Yes") || feedback.Answer.Contains("No"))
                {
                    feedback.Answers = new ObservableCollection<AnswerModel>();
                    feedback.Answers.Add(new AnswerModel { Answer = "Yes"});
                    feedback.Answers.Add(new AnswerModel { Answer = "No" });
                }
                else if (feedback.Answer.Contains("Excellent") || feedback.Answer.Contains("Good") || feedback.Answer.Contains("Average") || feedback.Answer.Contains("Poor"))
                {
                    feedback.Answers = new ObservableCollection<AnswerModel>();
                    feedback.Answers.Add(new AnswerModel { Answer = "Excellent" });
                    feedback.Answers.Add(new AnswerModel { Answer = "Good" });
                    feedback.Answers.Add(new AnswerModel { Answer = "Average" });
                    feedback.Answers.Add(new AnswerModel { Answer = "Poor" });
                }
                else if (feedback.Answer.Contains("Verylikely") || feedback.Answer.Contains("Likely") || feedback.Answer.Contains("Unlikely"))
                {
                    feedback.Answers = new ObservableCollection<AnswerModel>();
                    feedback.Answers.Add(new AnswerModel { Answer = "Verylikely" });
                    feedback.Answers.Add(new AnswerModel { Answer = "Likely" });
                    feedback.Answers.Add(new AnswerModel { Answer = "Unlikely" });
                }
                else if(feedback.Answer.Contains("High") || feedback.Answer.Contains("Moderate") || feedback.Answer.Contains("Low"))
                {
                    feedback.Answers = new ObservableCollection<AnswerModel>();
                    feedback.Answers.Add(new AnswerModel { Answer = "High" });
                    feedback.Answers.Add(new AnswerModel { Answer = "Moderate" });
                    feedback.Answers.Add(new AnswerModel { Answer = "Low" });
                }
            }
        }

        string[] Questions = new string[]
        {
            "How would you rate the quality of the content on this blog?",
            "Did you find the information provided useful and relevant?",
            "If the answer to the previous question is yes What specific aspect of the information did you find most useful or relevant?",
            "If the answer is no What aspects of the information did not meet your expectations or seem irrelevant?",
            "Are there any topics you’d like us to cover in the future?",
            "If the answer is yes What specific topics or areas would you like us to cover in future blog posts?",
            "If the answer is no Do you feel the current topics are sufficient, or is there something else you'd like to see more of?",
            "Was the blog post engaging and easy to read?",
            "Did the examples or illustrations enhance your understanding of the topic?",
            "If the answer is yes Which examples or illustrations were most helpful, and why?",
            "If the answer is no What kind of examples or illustrations would have helped improve your understanding of the topic?",
            "Was it easy to navigate the blog and find what you were looking for?",
            "If the answer is yes What aspects of the blog's navigation did you find most helpful?",
            "If the answer is no What improvements would you suggest to make navigation easier or help you find what you’re looking for more efficiently?",
            "How would you rate the visual appeal of the blog?",
            "Did the website load quickly and function smoothly on your device?",
            "If the answer is yes What aspects of the website's performance or functionality did you find particularly good?",
            "If the answer is no What issues did you experience with the website’s loading speed or functionality, and how could we improve performance?",
            "Were the fonts and formatting easy to read?",
            "If the answer is yes What specific aspects of the fonts and formatting did you find most helpful, and are there any additional improvements you would suggest?",
            "If the answer is no What specific issues did you encounter with the fonts and formatting, and how could we improve the readability?",
            "Are there any features or tools you’d like to see added to the blog?",
            "If the answer is yes What specific features or tools would you like to see added, and how would they improve your experience on the blog?",
            "If the answer is no Do you feel the current features and tools are sufficient, or is there something you feel is missing?",
            "Did you feel encouraged to leave a comment or interact with the post?",
            "If the answer is yes What aspects of the post encouraged you to interact, and do you have any suggestions for making the interaction experience even better?",
            "If the answer is no What changes could be made to encourage more interaction, such as comments or other forms of engagement?",
            "How likely are you to share this blog post with others?",
            "Would you subscribe to our newsletter or follow us for updates?",
            "If the answer is yes What aspects of the content or blog influenced your decision to subscribe or follow, and what would you like to see more of in future updates?",
            "If the answer is no What would make you more likely to subscribe to our newsletter or follow for updates?",            
            "Did you enjoy the multimedia (images, videos, or infographics) used in the blog?",
            "If the answer is yes What specific multimedia elements (images, videos, infographics) did you find most helpful, and how did they enhance your understanding of the content?",
            "If the answer is no What type of multimedia (images, videos, infographics) would you have preferred, or how could the current multimedia be improved to better support your understanding?",
            "What did you like most about this blog post?",
            "What could we improve to make your experience better?",
            "How likely are you to return to this blog for more content?",
            "Is there any feedback or suggestion you’d like to share with us?"
        };
        string[] Answers = new string[]
        {
         "Excellent",
"Yes",
"",
"",
"Yes",
"",
"",
"",
"Yes",
"",
"",
"Yes",
"",
"",
"High",
"Yes",
"",
"",
"Yes",
"",
"",
"Yes",
"",
"",
"Yes",
"",
"",
"Likely",
"Yes",
"",
"",
"Yes",
"",
"",
"",
"",
"Likely",
"",
        };

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}
