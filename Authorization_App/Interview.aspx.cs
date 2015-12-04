using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Authorization_App.Model;
using Authorization_App.BusinessServices;
using Authorization_App.BusinessRules;

namespace Authorization_App
{
    public partial class Interview : System.Web.UI.Page
    {
        protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();
        private List<IRuleAction> ruleActions;

        public Interview()
        {
            ruleActions = new List<IRuleAction>();
            ruleActions.Add(new SingleQuestionTypeAction() { Action = DisplayRadioBoxOptions });
            ruleActions.Add(new MultipleQuestionTypeAction() { Action = DisplayCheckBoxOptions });
            ruleActions.Add(new TextQuestionTypeAction() { Action = DisplayTextOption });
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["CurrentQuestionNumber"] = 0;
                NextQuestionBtn.Text = "Start";                
            }
        }



        protected void NextQuestionBtn_Click(object sender, EventArgs e)
        {
            int crrQuestionNum = (int) ViewState["CurrentQuestionNumber"];
            TestService testService = new TestService(_db);
            QuestionService questionService = new QuestionService(_db);
            Test ts = Session["Test"] as Test;
            Question q = null;
            if (ts!= null)
            {
                ClearAllOptions();
                q = testService.FindQuestionInTestByIndex(ts.Id, crrQuestionNum);
                if (q != null)
                {
                    QuestionText.Text = q.Description;
                    NextQuestionBtn.Text = testService.IsLastQuestionInTest(q, ts) ? "Finish Test" : "Next";
                    string type = questionService.GetQuestionType(q);                    
                    IRuleAction rule = ruleActions.FirstOrDefault(r => r.IsValidated(type));
                    rule.Action.Invoke();
                }
                else
                {
                    QuestionText.Text = "";
                    NextQuestionBtn.Text = "Submit Test";                    
                }
            }
            crrQuestionNum++;
            ViewState["CurrentQuestionNumber"] = crrQuestionNum;

        }

        private void ClearAllOptions()
        {
            RadioButtonListAnswer.Visible = false;
            CheckBoxListAnswer.Visible = false;
            TextBoxAnswer.Visible = false;
        }

        private void DisplayRadioBoxOptions()
        {
            int crrQuestionNum = (int) ViewState["CurrentQuestionNumber"];
            TestService testService = new TestService(_db);
            QuestionService questionService = new QuestionService(_db);
            Test ts = Session["Test"] as Test;
            Question q = testService.FindQuestionInTestByIndex(ts.Id, crrQuestionNum);
            RadioButtonListAnswer.Visible = true;
            List<string> optionsContent = new List<string>();
            foreach(QuestionOption qo in q.QuestionOption)
            {
                optionsContent.Add(qo.Content);
            }
            RadioButtonListAnswer.DataSource = optionsContent;
            RadioButtonListAnswer.DataBind();
        }

        private void DisplayCheckBoxOptions()
        {
            int crrQuestionNum = (int) ViewState["CurrentQuestionNumber"];
            TestService testService = new TestService(_db);
            QuestionService questionService = new QuestionService(_db);
            Test ts = Session["Test"] as Test;
            Question q = testService.FindQuestionInTestByIndex(ts.Id, crrQuestionNum);
            CheckBoxListAnswer.Visible = true;
            List<string> optionsContent = new List<string>();
            foreach (QuestionOption qo in q.QuestionOption)
            {
                optionsContent.Add(qo.Content);
            }
            CheckBoxListAnswer.DataSource = optionsContent;
            CheckBoxListAnswer.DataBind();
        }

        private void DisplayTextOption()
        {
            int crrQuestionNum = (int) ViewState["CurrentQuestionNumber"];
            TestService testService = new TestService(_db);
            QuestionService questionService = new QuestionService(_db);
            Test ts = Session["Test"] as Test;
            Question q = testService.FindQuestionInTestByIndex(ts.Id, crrQuestionNum);
            TextBoxAnswer.Visible = true;
        }
    }
}