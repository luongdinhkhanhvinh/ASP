using CDTH17.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDTH17.Models.Functions
{
    public class NguoiDungF
    {
        private MyDBContext context;
        public NguoiDungF()
        {
            context = new MyDBContext();
        }
        public IQueryable<viewQuyen> DSQuyen
        {
            get { return context.viewQuyens; }
        }

        public Account Login(string username, string pass)
        {
            var result = context.NguoiDungs.Where(a => 
                a.UserName.Equals(username) &&                                                     
                a.PassWord.Equals(pass)).FirstOrDefault();
            Account t = null;

            if (result != null)
            {
                t = new Account();
                t.UserName = result.UserName;
                t.Password = result.PassWord;
                //t.Roles = (from a in context.Roles
                //           join b in context.UserInRoles
                //           on a.IDRole equals b.IDRole
                //           where (a.RoleName != null && b.UserName.Equals(username))
                //           select a.RoleName).ToList();
            }
            return t;
        }




        // Trả về toàn bộ bảng
        public IQueryable<NguoiDung> DSNguoiDung
        {
            get { return context.NguoiDungs; }
        }
        // Trả về một đối tượng, khi biết Khóa
        public NguoiDung FindEntity(int Username)
        {
            NguoiDung dbEntry = context.NguoiDungs.Find(Username);
            return dbEntry;
        }

        // Thêm một đối tượng
        public string Insert(NguoiDung model)
        {
            NguoiDung dbEntry = context.NguoiDungs.Find(model.UserName);

            if (dbEntry != null)
            {
                return null;

            }
            context.NguoiDungs.Add(model);
            context.SaveChanges();
            return model.UserName;
        }

        // Sửa một đối tượng theo khóa
        public string Update(NguoiDung model)
        {
            NguoiDung dbEntry = context.NguoiDungs.Find(model.UserName);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return null;
            }
            dbEntry.PassWord = model.PassWord;
            dbEntry.HoTen = model.HoTen;

            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return model.UserName;
        }
       
        // Xóa một đối tượng theo Key
        public string Delete(string Username)
        {
            NguoiDung dbEntry = context.NguoiDungs.Find(Username);
            if (dbEntry == null)
            {
                return null;
            }
            context.NguoiDungs.Remove(dbEntry);
            context.SaveChanges();
            return Username;
        }
    }
}