using Angarola.Web.Domain;
using Angarola.Web.Models.Requests;
using Sabio.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Angarola.Web.Services
{
    public class BrandService : BaseService
    {
        public static int Insert(BrandsRequestModel model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Brands_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Name", model.Name);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@ImageURL", model.ImageURL);
                   paramCollection.AddWithValue("@LookbookURL", model.LookbookURL);
                   paramCollection.AddWithValue("@LinesheetURL", model.LinesheetURL);

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

        public static void Update(BrandsUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Brands_Update"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", model.Id);
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Description", model.Description);
                    paramCollection.AddWithValue("@ImageURL", model.ImageURL);
                    paramCollection.AddWithValue("@LookbookURL", model.LookbookURL);
                    paramCollection.AddWithValue("@LinesheetURL", model.LinesheetURL);
                }
                );
        }

        public static Brand GetById(int id)
        {
            Brand x = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Brands_SelectById"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                },
                map: delegate (IDataReader reader, short set)
                {
                    x = MapBrands(reader);
                }
                );

            return x;
        }

        public static List<Brand> GetAll()
        {
            List<Brand> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Brands_SelectAll"
               , inputParamMapper: null
               , map: delegate (IDataReader reader, short set)
               {
                   Brand x = MapBrands(reader);

                   if (list == null)
                   {
                       list = new List<Brand>();
                   }
                   list.Add(x);
               }
               );
            return list;
        }

        public static void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Brands_Delete"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }
                );
        }

        private static Brand MapBrands(IDataReader reader)
        {
            Brand x = new Brand();
            int colpos = 0;

            x.Id = reader.GetSafeInt32(colpos++);
            x.Name = reader.GetSafeString(colpos++);
            x.Description = reader.GetSafeString(colpos++);
            x.ImageURL = reader.GetSafeString(colpos++);
            x.LookbookURL = reader.GetSafeString(colpos++);
            x.LinesheetURL = reader.GetSafeString(colpos++);

            return x;
        }
    }
}