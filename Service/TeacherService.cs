using Model;
using Repository;
using RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service
{
    public class TeacherService:BaseService<Teacher, TeacherRequestModel, TeacherViewModel>
    {
        public TeacherService(IBaseRepository<Teacher> repository):base(repository)
        { }
    }
}
