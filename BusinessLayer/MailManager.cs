using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Migrations;
using EntityLayer.Concrete;

namespace BusinessLayer
{
    public class MailManager:IGenericService<MailSubscribe>
    {
        private readonly IGenericDal<MailSubscribe> _MailsubscribeDal;


        public MailManager(IGenericDal<MailSubscribe> mailSubscribe)
        {
            _MailsubscribeDal = mailSubscribe;
        }

        public void Add(MailSubscribe t)
        {
            _MailsubscribeDal.Insert(t);
        }

        public void Delete(MailSubscribe t)
        {
            throw new NotImplementedException();
        }

        public MailSubscribe GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MailSubscribe> List()
        {
            throw new NotImplementedException();
        }

        public void Update(MailSubscribe t)
        {
            throw new NotImplementedException();
        }
    }
}
