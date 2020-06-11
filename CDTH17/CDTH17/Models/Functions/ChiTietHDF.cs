using CDTH17.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDTH17.Models.Functions
{
    public class ChiTietHDF
    {
        private MyDBContext context;
        public ChiTietHDF()
        {
            context = new MyDBContext();
        }
        // Trả về toàn bộ bảng
        public IQueryable<CHITIETHD> DSCHITIETHD
        {
            get { return context.CHITIETHDs; }
        }
        // Trả về một đối tượng, khi biết Khóa
        public CHITIETHD FindEntity(int MaHD, string MaSP)
        {
            CHITIETHD dbEntry = context.CHITIETHDs.Find(MaHD,MaSP);
            return dbEntry;
        }

        // Thêm một đối tượng
        public int Insert(CHITIETHD model)
        {
            CHITIETHD dbEntry = context.CHITIETHDs.Find(model.MaHD,model.MaSP);

            if (dbEntry != null)
            {
                return -1;

            }
            context.CHITIETHDs.Add(model);
            context.SaveChanges();
            return model.MaHD;
        }

        // Sửa một đối tượng theo khóa
        public int Update(CHITIETHD model)
        {
            CHITIETHD dbEntry = context.CHITIETHDs.Find(model.MaHD,model.MaSP);
            //   LoaiBanDoc dbEntry = context.LoaiBanDocs.
            //  Where(x => x.LoaiBanDoc1 = model.LoaiBanDoc1).FirstOrDefault();
            if (dbEntry == null)
            {
                return -1;
            }
            dbEntry.SoLuong = model.SoLuong;
            dbEntry.DonGia = model.DonGia;
            
            // Sửa các trường khác cũng như vậy
            context.SaveChanges();

            return model.MaHD;
        }
       
        // Xóa một đối tượng theo Key
        public int Delete(int MaHD, string MaSP)
        {
            CHITIETHD dbEntry = context.CHITIETHDs.Find(MaHD, MaSP);
            if (dbEntry == null)
            {
                return -1;
            }
            context.CHITIETHDs.Remove(dbEntry);
            context.SaveChanges();
            return MaHD;
        }
    }
}