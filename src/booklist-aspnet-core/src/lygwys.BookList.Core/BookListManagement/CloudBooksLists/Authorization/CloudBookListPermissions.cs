

namespace lygwys.BookList.BookListManagement.CloudBooksLists.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="CloudBookListAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class CloudBookListPermissions
	{
		/// <summary>
		/// CloudBookList权限节点
		///</summary>
		public const string Node = "Pages.CloudBookList";

		/// <summary>
		/// CloudBookList查询授权
		///</summary>
		public const string Query = "Pages.CloudBookList.Query";

		/// <summary>
		/// CloudBookList创建权限
		///</summary>
		public const string Create = "Pages.CloudBookList.Create";

		/// <summary>
		/// CloudBookList修改权限
		///</summary>
		public const string Edit = "Pages.CloudBookList.Edit";

		/// <summary>
		/// CloudBookList删除权限
		///</summary>
		public const string Delete = "Pages.CloudBookList.Delete";

        /// <summary>
		/// CloudBookList批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.CloudBookList.BatchDelete";

		/// <summary>
		/// CloudBookList导出Excel
		///</summary>
		public const string ExportExcel="Pages.CloudBookList.ExportExcel";

		 
		 
         
    }

}

