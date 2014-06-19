using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOffline.Models
{
    public class DocumentsRepository
    {
        public int AddContent(string userName, string content)
        {
            Accounting acc = null;
            using (DocumentsDataContext dc = new DocumentsDataContext())
            {
                acc = new Accounting
                {
                    UserName = userName,
                    Content = content
                };
                dc.Accountings.InsertOnSubmit(acc);
                dc.SubmitChanges();
            }
            return acc.Id;
        }

        public void AddClipping(Accounting accounting, string userName, string clipping)
        {
            using (DocumentsDataContext dc = new DocumentsDataContext())
            {
                var acc = dc.Accountings.FirstOrDefault(a => a.Id == accounting.Id);
                acc.Clipping = clipping;
                acc.UserName = userName;
                dc.SubmitChanges();
            }
        }
    }
}