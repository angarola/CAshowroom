using Angarola.Web.Domain;
using Angarola.Web.Models.Requests;
using Sabio.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Angarola.Web.Services
{
    public class CalendarService : BaseService
    {
        public static int Insert(CalendarRequest model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Calendar_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Dates", model.Dates);

                    SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
                    p.Direction = ParameterDirection.Output;

                    paramCollection.Add(p);
                }
                , returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out id);
                }
               );

            return id;
        }

        public static void Update(CalendarUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Brands_Update"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", model.Id);
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Dates", model.Dates);
                }
                );
        }

        public static Calendar GetById(int id)
        {
            Calendar x = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Calendar_SelectById"
                 , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                 {
                     paramCollection.AddWithValue("@Id", id);
                 },
                map: delegate (IDataReader reader, short set)
                {
                    x = MapCalendar(reader);
                }
                );

            return x;
        }

        public static List<Calendar> GetAll()
        {
            List<Calendar> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Calendar_SelectAll"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   Calendar x = MapCalendar(reader);

                   if (list == null)
                   {
                       list = new List<Calendar>();
                   }
                   list.Add(x);
               }
               );
            return list;
        }

        public static void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Calendar_Delete"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }
                );
        }

        private static Calendar MapCalendar(IDataReader reader)
        {
            Calendar x = new Calendar();
            int colpos = 0;

            x.Id = reader.GetSafeInt32(colpos++);
            x.Name = reader.GetSafeString(colpos++);
            x.Dates = reader.GetSafeString(colpos++);

            return x;
        }

    }
}