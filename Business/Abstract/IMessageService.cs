using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IResult Add(Message message);
        IResult Update(Message message);
        IResult Delete(int id);
        IDataResult<List<Message>> GetAllMessage();
        IDataResult<Message> GetMessage(int id);
        IDataResult<List<Message>> GetMessagebySpecial(string param);

        IDataResult<List<AboutMessageDto>> GetAllMessagesByAbout();

    }
}
