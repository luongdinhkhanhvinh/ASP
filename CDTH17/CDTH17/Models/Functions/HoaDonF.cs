using CDTH17.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDTH17.Models.Functions
{
    public class HoaDonF
    {
        private MyDBContext context;
        public HoaDonF()
        {
            context = new MyDBContext();
        }
        // Trả về toàn bộ bảng
        public IQueryable<HOADON> DSHOADON
        {
            get { return context.HOADONs; }
        }
        // Trả về một đối tượng, khi biết Khóa
        public HOADON FindEntity(int MaDM)
        {
            HOADON dbEntry = context.HOADONs.Find(MaDM);
            return dbEntry;
        }

        // Thêm một đối tượng
        public int Insert(HOADON model)
        {
            HOADON dbEntry = context.HOADONs.Find(model.MaHD);

            if (dbEntry != null)
            {
                return -1;

            }
            context.HOADONs.Add(model);
            context.SaveChanges();
            return model.MaHD;
        }

        // Sửa một đối tượng theo khóa
        public int Update(HOADON model)
        {
            HOADON dbEntry = context.HOADONs.Find(model.MaHD);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return -1;
            }
            dbEntry.NgayHD = model.NgayHD;
            dbEntry.Hoten = model.Hoten;
            dbEntry.DiaChi = model.DiaChi;
            dbEntry.DienThoai = model.DienThoai;
            dbEntry.EMail = model.EMail;
            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return model.MaHD;
        }
       
        // Xóa một đối tượng theo Key
        public int Delete(int MaHD)
        {
            HOADON dbEntry = context.HOADONs.Find(MaHD);
            if (dbEntry == null)
            {
                return -1;
            }
            context.HOADONs.Remove(dbEntry);
            context.SaveChanges();
            return MaHD;
        }
    }
}