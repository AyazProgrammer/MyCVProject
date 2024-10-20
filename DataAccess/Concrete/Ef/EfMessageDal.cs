using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Concrete.EF
{
    public class EfMessageDal : BaseRepository<Message, BaseProjectContext> , IMessageDal  
    {
        public EfMessageDal(BaseProjectContext context) : base(context) 
        {
            
        }

        public List<AboutMessageDto> GetAllMessagessByAbout()
        {
            var context = new BaseProjectContext();

            var result = from m in context.Messages
                         where m.IsDeleted == false 
                         join a in context.Abouts
                         on m.AboutId equals a.Id
                         where a.IsDeleted == false
                         select new AboutMessageDto
                         {
                             AboutId=a.Id,
                            
                             Email = m.Email,
                             
                             MessageId = m.Id,
                             MessageInfo = m.MessageInfo,
                             Name = m.Name,
                             Phone = m.Phone,
                             
                             
                            
                            

                            

                            
                         };
            return result.ToList();

        }
     

    


  
      
       

     


    }
}
