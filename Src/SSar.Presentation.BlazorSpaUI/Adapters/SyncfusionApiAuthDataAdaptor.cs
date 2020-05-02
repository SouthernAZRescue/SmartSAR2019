using System;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace SSar.Presentation.BlazorSpaUI.Adapters
{
    public class SyncfusionApiAuthDataAdaptor : DataAdaptor
    {
        /// <summary>
        /// Performs data Read operation synchronously.
        /// </summary>
        public override object Read(DataManagerRequest dataManagerRequest, string key = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs data Read operation asynchronously.
        /// </summary>
            public override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            throw new NotImplementedException();
        }

            /// <summary>
            /// Performs Insert operation synchronously.
            /// </summary>
            public override object Insert(DataManager dataManager, object data, string key)
        {
            throw new NotImplementedException();
        }
            /// <summary>
            /// Performs Insert operation asynchronously.
            /// </summary>
            public override Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            throw new NotImplementedException();
        }

            /// <summary>
            /// Performs Remove operation synchronously.
            /// </summary>
            public override object Remove(DataManager dataManager, object data, string keyField, string key)
        {
            throw new NotImplementedException();
        }

            /// <summary>
            /// Performs Remove operation asynchronously..
            /// </summary>
            public override Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key)
        {
            throw new NotImplementedException();
        }

            /// <summary>
            /// Performs Update operation synchronously.
            /// </summary>
            public override object Update(DataManager dataManager, object data, string keyField, string key)
        {
            throw new NotImplementedException();
        }

            /// <summary>
            /// Performs Update operation asynchronously.
            /// </summary>
            public override Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            throw new NotImplementedException();
        }

            /// <summary>
            /// Performs Batch CRUD operations synchronously.
            /// </summary>
            public object BatchUpdate(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key)
        {
            throw new NotImplementedException();
        }

            /// <summary>
            /// Performs Batch CRUD operations asynchronously.
            /// </summary>
            public Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key)
        {
            throw new NotImplementedException();
        }
    }
}
