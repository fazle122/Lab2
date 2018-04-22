using Common.RequestModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RequestModel
{
    public class TeacherRequestModel:BaseRequestModel<Teacher>
    {
        public string keyword { get; set; }
        public double mincredit { get; set; }
        public double maxcredit { get; set; }

        //public TeacherRequestModel(double minCredit, double maxCredit,string keyword,string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        //{
        //    mincredit = minCredit;
        //    maxcredit = maxCredit;
        //}

        public TeacherRequestModel(string keyword, string orderBy, string isAscending) : base(keyword, orderBy, isAscending)
        {

        }



        protected override Expression<Func<Teacher,bool>> GetExpression()
        {
            Keyword = Keyword.ToLower();
            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                ExpressionObj = obj => obj.Name.Contains(Keyword) || obj.Phone.Contains(Keyword) || obj.Courses.Contains(Keyword);
            }
            //if(mincredit > 0)
            //{
            //    ExpressionObj = ExpressionObj.And(obj => obj.minCredit);
            //}
            //if (maxcredit > 0)
            //{
            //    ExpressionObj = ExpressionObj.And(obj => obj.min);
            //}


            return ExpressionObj;
        }
    }
}
