using Dapper;
using Ecommerce.Modal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GroupMeeting.Services
{

    public interface IProgramService
    {
        Task<ProgramModel> GetProgramById(int Id);
    }

    public class ProgramService : IProgramService
    {
        private IConfiguration _config;
        public ProgramService(IConfiguration configuration)
        {
            _config = configuration;
        }
        //public IConfiguration Configuration { get; }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        /*  public IDbConnection Connection
          {
              get
              {
                  return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
              }
          }*/

        /*   public int Add(ProgramCreateViewModel model)
           {
               try
               {
                   ProgramModel asc = new ProgramModel
                   {
                       Program_Title = model.Program_Title,
                       Program_Content = model.Program_Content

                   };
                   PhotoModel photoModel = new PhotoModel();
                   photoModel.Photos = _photoServices.ProcessUploadFile(model.PhotoPath);

                   using (IDbConnection con = Connection)
                   {
                       if (con.State == ConnectionState.Closed)
                       {
                           con.Open();
                       }

                       using (var tran = con.BeginTransaction())
                       {
                           try
                           {
                               DynamicParameters programParam = new DynamicParameters();
                               programParam.Add("@Program_Title", model.Program_Title);
                               programParam.Add("@Program_Content", model.Program_Content);

                               DynamicParameters photoParam = new DynamicParameters();
                               photoParam.Add("@Photos", photoModel.Photos);

                               int id = con.ExecuteScalar<int>("Sp_Insert_Programs", programParam,tran, commandType: CommandType.StoredProcedure);
                               con.ExecuteScalar<PhotoModel>("sp_Insert_Photos_by_ID", photoParam, tran, commandType: CommandType.StoredProcedure);
                               tran.Commit();
                               return 1;
                           }
                           catch (Exception ex)
                           {
                               tran.Rollback();
                               return 0;
                           }

                       }

                   }*/

        /* //using (IDbConnection con = Connection)
         //{
         //    if (con.State == ConnectionState.Closed)
         //    {
         //        con.Open();
         //    }

         //    DynamicParameters parameters = new DynamicParameters();
         //    parameters.Add("@Program_Title", model.Program_Title);
         //    parameters.Add("@Program_Content", model.Program_Content);
         //    parameters.Add("@Admin_Id", model.Admin_ID);


         //    asc = con.Query<ProgramModel>("Sp_Insert_Programs", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
         //}
         //return asc;*/

        /*    }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/
        /*
                public ProgramModel Delete(int Id)
                {
                    try
                    {
                        ProgramModel asc = new ProgramModel();
                        using (IDbConnection con = Connection)
                        {
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add("@Program_ID", Id);

                            con.Query<ProgramModel>("Sp_Delete_Programs", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                        }
                        return asc;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
        */
        /*      public IEnumerable<ProgramModel> GetAllPrograms()
              {
                  try
                  {
                      List<ProgramModel> asc = new List<ProgramModel>();
                      using (IDbConnection con = Connection)
                      {
                          if (con.State == ConnectionState.Closed)
                          {
                              con.Open();
                          }


                          asc = con.Query<ProgramModel>("Sp_Select_Programs").ToList();

                      }
                      return asc;

                  }
                  catch (Exception ex)
                  {

                      throw ex;
                  }

              }*/

        public async Task<ProgramModel> GetProgramById(int Id)
        {
            try
            {
                ProgramModel asc = new ProgramModel();
                using (IDbConnection con = Connection)
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    /*DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Program_ID", Id);*/

                    asc = await con.QueryFirstOrDefaultAsync<ProgramModel>("Sp_Select_Programs_by_Id", new { @Program_ID = Id }, commandType: CommandType.StoredProcedure);
                }

                return asc;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /*   public ProgramModel Update(ProgramModel programChange)
           {
               try
               {
                   ProgramModel asc = new ProgramModel();

                   using (IDbConnection con = Connection)
                   {
                       if (con.State == ConnectionState.Closed)
                       {
                           con.Open();
                       }

                       DynamicParameters parameters = new DynamicParameters();
                       parameters.Add("@Program_ID", programChange.Program_ID);
                       parameters.Add("@Program_Title", programChange.Program_Title);
                       parameters.Add("@Program_Content", programChange.Program_Content);

                       con.Query<ProgramModel>("Sp_Update_Programs", parameters, commandType: CommandType.StoredProcedure);

                   }
                   return programChange;

               }
               catch (Exception ex)
               {

                   throw ex;
               }
           }*/










    }
}
