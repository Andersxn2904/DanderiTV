using DanderiTV.Layer.Application.Interfaces.Repositories;
using DanderiTV.Layer.DataAccess.Contexts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;

namespace DanderiTV.Layer.Application.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        IDbConnection _dbConnetion;
     

        public GenericRepository(DapperContext context)
        {
            _dbConnetion = context.CreateConnection();

        }

        public async Task<T> Add(T entity)
        {
            int rowsEffected = 0; 
            try
            {
                string tableName = GetTableName();
                string columns = GetColumns(excludekey: true); 
                string properties = GetPropertyName(exclude: true);
                string Query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";
            }
            catch 
            (Exception ex) 
            { 
            
            }
        }


        #region Shared Methods Private

        //Get the column name based on the Entity name
        private string GetTableName()
        {
            string tableName = "";
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            if (tableAttr != null)
            {
                tableName = tableAttr.Name;
                return tableName;
            }
            return type.Name + "s";
        }
        // Get the name of Key Column's entity
        public static string GetKeyColumnTable()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object[] KeyAttributes = property.GetCustomAttributes(typeof(KeyAttribute), true);

                if(KeyAttributes != null && KeyAttributes.Length > 0)
                {
                    object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (columnAttributes != null && columnAttributes.Length > 0)
                    {
                        ColumnAttribute columnAttribute = (ColumnAttribute)columnAttributes[0];
                        return columnAttribute.Name;
                    }
                    else
                    {
                        return property.Name;
                    }
                }
            }
            return null;
        }



        #endregion

    }
}
