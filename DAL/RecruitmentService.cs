using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
   public class RecruitmentService
    {
        /// <summary>
        /// 查询招聘信息（需要返回PostId，否则删除时没有PostId不能操作）
       /// </summary>
       /// <returns></returns>
       public List<Recruitment> GetRecruitment()
       {
           string sql = "select PostId,PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email from recruitment";
           
           List<Recruitment> list = new List<Recruitment>();
           SqlDataReader objReader = SQLHelp.GetReader(sql);
           while(objReader.Read())
           {
               list.Add(new Recruitment(){
                    PostId = Convert.ToInt32(objReader["PostId"]),
                    PostName = objReader["PostName"].ToString(),
                    PostType = objReader["PostType"].ToString(),
                    PostPlace = objReader["PostPlace"].ToString(),
                    PostDesc = objReader["PostDesc"].ToString(),
                    PostRequire = objReader["PostRequire"].ToString(),
                    Experience = objReader["Experience"].ToString(),
                    EduBackground = objReader["EduBackground"].ToString(),
                    RequireCount =Convert.ToInt32(objReader["RequireCount"]),
                    Manager = objReader["Manager"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Email = objReader["Email"].ToString()

               });                          
                
           }
           objReader.Close();
           return list;           
       }

       /// <summary>
       /// 删除选定的招聘信息
       /// </summary>
       /// <param name="postId"></param>
       /// <returns></returns>
       public int DeleteRecruitment(string postId)
       {
           string sql = "delete from recruitment where PostId=@PostId";
           SqlParameter[] param = new SqlParameter[]{
            new SqlParameter("@PostId",postId)
           };
           return SQLHelp.Update(sql, param);
       }
       /// <summary>
       /// 发布招聘信息
       /// </summary>
       /// <param name="objRecruitment"></param>
       /// <returns></returns>
       public int AddRecruitment(Recruitment objRecruitment)
       {
           string sql = "insert into Recruitment(PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email)";
           sql += " values(@PostName,@PostType,@PostPlace,@PostDesc,@PostRequire,@Experience,@EduBackground,@RequireCount,@Manager,@PhoneNumber,@Email)";
           SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@PostName",objRecruitment.PostName),
                new SqlParameter("@PostType",objRecruitment.PostType),
                new SqlParameter("@PostPlace",objRecruitment.PostPlace),
                new SqlParameter("@PostDesc",objRecruitment.PostDesc),
                new SqlParameter("@PostRequire",objRecruitment.PostRequire),
                new SqlParameter("@Experience",objRecruitment.Experience),
                new SqlParameter("@EduBackground",objRecruitment.EduBackground),
                new SqlParameter("@RequireCount",objRecruitment.RequireCount),
                new SqlParameter("@Manager",objRecruitment.Manager),
                new SqlParameter("@PhoneNumber",objRecruitment.PhoneNumber),
                new SqlParameter("@Email",objRecruitment.Email),
           };
           return SQLHelp.Update(sql, param);
       }

       /// <summary>
       /// 根据编号查询职位详细信息
       /// </summary>
       /// <param name="postId"></param>
       /// <returns></returns>
       public Recruitment GetRecruitmentById(string postId)
       {
           string sql = "select PostId,PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email from recruitment where PostId=@PostId";
           SqlParameter[] param = new SqlParameter[] { 
            new SqlParameter("@PostId",postId)
           };
           Recruitment objRecruitment = null;           
           SqlDataReader objReader = SQLHelp.GetReader(sql,param);
           while (objReader.Read())
           {
               objRecruitment = new Recruitment() {
                   PostId = Convert.ToInt32(objReader["PostId"]),
                   PostName = objReader["PostName"].ToString(),
                   PostType = objReader["PostType"].ToString(),
                   PostPlace = objReader["PostPlace"].ToString(),
                   PostDesc = objReader["PostDesc"].ToString(),
                   PostRequire = objReader["PostRequire"].ToString(),
                   Experience = objReader["Experience"].ToString(),
                   EduBackground = objReader["EduBackground"].ToString(),
                   RequireCount = Convert.ToInt32(objReader["RequireCount"]),
                   Manager = objReader["Manager"].ToString(),
                   PhoneNumber = objReader["PhoneNumber"].ToString(),
                   Email = objReader["Email"].ToString()
               };             

           }
           objReader.Close();
           return objRecruitment;
       }

       /// <summary>
       /// 根据编号修改职位详细信息
       /// </summary>
       /// <param name="postId"></param>
       /// <returns></returns>
       public int ModifyRecruitment(Recruitment objRecruitment)
       {
           string sql = "update Recruitment set PostName=@PostName,PostType=@PostType,PostPlace=@PostPlace,PostDesc=@PostDesc,PostRequire=@PostRequire,Experience=@Experience,EduBackground=@EduBackground,RequireCount=@RequireCount,Manager=@Manager,PhoneNumber=@PhoneNumber,Email=@Email where PostId=@PostId";
           SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@PostName",objRecruitment.PostName),
                new SqlParameter("@PostType",objRecruitment.PostType),
                new SqlParameter("@PostPlace",objRecruitment.PostPlace),
                new SqlParameter("@PostDesc",objRecruitment.PostDesc),
                new SqlParameter("@PostRequire",objRecruitment.PostRequire),
                new SqlParameter("@Experience",objRecruitment.Experience),
                new SqlParameter("@EduBackground",objRecruitment.EduBackground),
                new SqlParameter("@RequireCount",objRecruitment.RequireCount),
                new SqlParameter("@Manager",objRecruitment.Manager),
                new SqlParameter("@PhoneNumber",objRecruitment.PhoneNumber),
                new SqlParameter("@Email",objRecruitment.Email),
                new SqlParameter("@PostId",objRecruitment.PostId)
           };
           return SQLHelp.Update(sql, param);
       }
    }
}
