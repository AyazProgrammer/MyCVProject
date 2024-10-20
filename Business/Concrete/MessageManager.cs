using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager(IMessageDal messageDal) : IMessageService
    {

        private readonly IMessageDal _messageDal = messageDal;


       // [ValidationAspect<Product>(typeof(MessageValidator))]
        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult("message elave olundu");
        }

        public IResult Delete(int id)
        {
            Message deleteMessage = null;
            Message resultMessage = _messageDal.Get(m => m.IsDeleted == false && m.Id == id);
            if (resultMessage != null)
                deleteMessage = resultMessage;
            deleteMessage.IsDeleted = true;
            _messageDal.Delete(deleteMessage);
            return new SuccessResult();
        }

        public IDataResult<List<Message>> GetAllMessage()
        {
            var messages = _messageDal.GetAll(m => m.IsDeleted == false).ToList();
            if (messages.Count > 0)
                return new SuccessDataResult<List<Message>>(messages);
            else return new ErrorDataResult<List<Message>>("xeta bash verdi");
        }

        public IDataResult<List<AboutMessageDto>> GetAllMessagesByAbout()
        {
            var messages = _messageDal.GetAllMessagessByAbout().ToList();
            if (messages.Count > 0)
                return new SuccessDataResult<List<AboutMessageDto>>(messages,"siyahi geldi");
            else return new ErrorDataResult<List<AboutMessageDto>>("xeta bash verdi");
        }

        public IDataResult<Message> GetMessage(int id)
        {
            Message getMessage = _messageDal.Get(m => m.Id == id);

            if (getMessage != null)
                return new SuccessDataResult<Message>(getMessage, "get message loaded");
            else return new ErrorDataResult<Message>(getMessage, "message tapilmadi");
        }

        public IDataResult<List<Message>> GetMessagebySpecial(string param)
        {
            var messages = _messageDal.GetAll(m => m.IsDeleted == false &&( m.Name== param ||m.Email==param||m.AboutId.ToString()==param)).ToList();
            if (messages.Count > 0)
                return new SuccessDataResult<List<Message>>(messages);
            else return new ErrorDataResult<List<Message>>("xeta bash verdi");
        }

        public IResult Update(Message message)
        {
            Message updateMessage;
            updateMessage = _messageDal.Get(m => m.Id == message.Id && m.IsDeleted == false);
            updateMessage.Id = message.Id;
            updateMessage.IsDeleted = message.IsDeleted;
            updateMessage.Phone = message.Phone;
            updateMessage.Email = message.Email;
            _messageDal.Update(message);
            return new SuccessResult();
        }
    }

       
    
}
