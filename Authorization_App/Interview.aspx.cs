using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Authorization_App.Model;
using Authorization_App.BusinessServices;

namespace Authorization_App
{
    public partial class Interview : System.Web.UI.Page
    {
        protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //TestService testService = new TestService(_db);
                //QuestionService questionService = new QuestionService(_db);
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
                q = testService.FindQuestionInTestByIndex(ts.Id, crrQuestionNum);
                if (q != null)
                {
                    QuestionText.Text = q.Description;
                    NextQuestionBtn.Text = testService.IsLastQuestionInTest(q, ts) ? "Finish Test" : "Next";
                    string type = questionService.GetQuestionType(q);
                    switch(type)
                    {
                        case "Single":
                            {                                
                                RadioButtonListAnswer.Visible = true;
//                                RadioButtonListAnswer.DataSource = q.QuestionOption;
                                var qoptions = new List<string>();
                                qoptions.Add("option 1");
                                qoptions.Add("option 2");
                                qoptions.Add("option 3");
                                RadioButtonListAnswer.DataSource = qoptions;
                                RadioButtonListAnswer.DataBind();
                            }
                            break;
                        case "Multiple":
                            {
                                var qoptions = new List<string>();
                                qoptions.Add("option 1");
                                qoptions.Add("option 2");
                                qoptions.Add("option 3");
                                CheckBoxListAnswer.Visible = true;
                                //CheckBoxListAnswer.DataSource = q.QuestionOption;
                                CheckBoxListAnswer.DataSource = qoptions;
                                CheckBoxListAnswer.DataBind();
                            }
                            break;
                        case "Code":
                            {
                                TextBoxAnswer.Visible = true;
                            }
                            break;
                        case "Text":
                            {
                                TextBoxAnswer.Visible = true;
                            }
                            break;
                        default:
                            {

                            }
                            break;
                    }

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
    }
}