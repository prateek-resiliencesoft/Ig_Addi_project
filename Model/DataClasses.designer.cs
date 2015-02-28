﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocialPanel.Model
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="C325018_IGPanel")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblAccesstoken(tblAccesstoken instance);
    partial void UpdatetblAccesstoken(tblAccesstoken instance);
    partial void DeletetblAccesstoken(tblAccesstoken instance);
    partial void InserttblOrder(tblOrder instance);
    partial void UpdatetblOrder(tblOrder instance);
    partial void DeletetblOrder(tblOrder instance);
    partial void InserttblPlan(tblPlan instance);
    partial void UpdatetblPlan(tblPlan instance);
    partial void DeletetblPlan(tblPlan instance);
    partial void Inserttbl_CutomerDetail(tbl_CutomerDetail instance);
    partial void Updatetbl_CutomerDetail(tbl_CutomerDetail instance);
    partial void Deletetbl_CutomerDetail(tbl_CutomerDetail instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["C325018_IGPanelConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblAccesstoken> tblAccesstokens
		{
			get
			{
				return this.GetTable<tblAccesstoken>();
			}
		}
		
		public System.Data.Linq.Table<tblOrder> tblOrders
		{
			get
			{
				return this.GetTable<tblOrder>();
			}
		}
		
		public System.Data.Linq.Table<tblPlan> tblPlans
		{
			get
			{
				return this.GetTable<tblPlan>();
			}
		}
		
		public System.Data.Linq.Table<tbl_CutomerDetail> tbl_CutomerDetails
		{
			get
			{
				return this.GetTable<tbl_CutomerDetail>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="C325018_IGPanel.tblAccesstoken")]
	public partial class tblAccesstoken : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _UserID;
		
		private string _UserName;
		
		private string _AccessToken;
		
		private string _IsActive;
		
		private string _DateTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(string value);
    partial void OnUserIDChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnAccessTokenChanging(string value);
    partial void OnAccessTokenChanged();
    partial void OnIsActiveChanging(string value);
    partial void OnIsActiveChanged();
    partial void OnDateTimeChanging(string value);
    partial void OnDateTimeChanged();
    #endregion
		
		public tblAccesstoken()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccessToken", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string AccessToken
		{
			get
			{
				return this._AccessToken;
			}
			set
			{
				if ((this._AccessToken != value))
				{
					this.OnAccessTokenChanging(value);
					this.SendPropertyChanging();
					this._AccessToken = value;
					this.SendPropertyChanged("AccessToken");
					this.OnAccessTokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsActive", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this.OnIsActiveChanging(value);
					this.SendPropertyChanging();
					this._IsActive = value;
					this.SendPropertyChanged("IsActive");
					this.OnIsActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateTime", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string DateTime
		{
			get
			{
				return this._DateTime;
			}
			set
			{
				if ((this._DateTime != value))
				{
					this.OnDateTimeChanging(value);
					this.SendPropertyChanging();
					this._DateTime = value;
					this.SendPropertyChanged("DateTime");
					this.OnDateTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="C325018_IGPanel.tblOrder")]
	public partial class tblOrder : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _OrderId;
		
		private string _OrderNumber;
		
		private string _Url;
		
		private System.Nullable<int> _Amount;
		
		private System.Nullable<System.DateTime> _OrderDate;
		
		private System.Nullable<int> _StartPoint;
		
		private System.Nullable<int> _EndPoint;
		
		private System.Nullable<int> _CurrentCount;
		
		private string _OrderStatus;
		
		private System.Nullable<System.DateTime> _LastUpdateDate;
		
		private string _OrderType;
		
		private string _UserName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOrderIdChanging(int value);
    partial void OnOrderIdChanged();
    partial void OnOrderNumberChanging(string value);
    partial void OnOrderNumberChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    partial void OnAmountChanging(System.Nullable<int> value);
    partial void OnAmountChanged();
    partial void OnOrderDateChanging(System.Nullable<System.DateTime> value);
    partial void OnOrderDateChanged();
    partial void OnStartPointChanging(System.Nullable<int> value);
    partial void OnStartPointChanged();
    partial void OnEndPointChanging(System.Nullable<int> value);
    partial void OnEndPointChanged();
    partial void OnCurrentCountChanging(System.Nullable<int> value);
    partial void OnCurrentCountChanged();
    partial void OnOrderStatusChanging(string value);
    partial void OnOrderStatusChanged();
    partial void OnLastUpdateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnLastUpdateDateChanged();
    partial void OnOrderTypeChanging(string value);
    partial void OnOrderTypeChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    #endregion
		
		public tblOrder()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int OrderId
		{
			get
			{
				return this._OrderId;
			}
			set
			{
				if ((this._OrderId != value))
				{
					this.OnOrderIdChanging(value);
					this.SendPropertyChanging();
					this._OrderId = value;
					this.SendPropertyChanged("OrderId");
					this.OnOrderIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderNumber", DbType="VarChar(50)")]
		public string OrderNumber
		{
			get
			{
				return this._OrderNumber;
			}
			set
			{
				if ((this._OrderNumber != value))
				{
					this.OnOrderNumberChanging(value);
					this.SendPropertyChanging();
					this._OrderNumber = value;
					this.SendPropertyChanged("OrderNumber");
					this.OnOrderNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="VarChar(150)")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Int")]
		public System.Nullable<int> Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> OrderDate
		{
			get
			{
				return this._OrderDate;
			}
			set
			{
				if ((this._OrderDate != value))
				{
					this.OnOrderDateChanging(value);
					this.SendPropertyChanging();
					this._OrderDate = value;
					this.SendPropertyChanged("OrderDate");
					this.OnOrderDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartPoint", DbType="Int")]
		public System.Nullable<int> StartPoint
		{
			get
			{
				return this._StartPoint;
			}
			set
			{
				if ((this._StartPoint != value))
				{
					this.OnStartPointChanging(value);
					this.SendPropertyChanging();
					this._StartPoint = value;
					this.SendPropertyChanged("StartPoint");
					this.OnStartPointChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndPoint", DbType="Int")]
		public System.Nullable<int> EndPoint
		{
			get
			{
				return this._EndPoint;
			}
			set
			{
				if ((this._EndPoint != value))
				{
					this.OnEndPointChanging(value);
					this.SendPropertyChanging();
					this._EndPoint = value;
					this.SendPropertyChanged("EndPoint");
					this.OnEndPointChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrentCount", DbType="Int")]
		public System.Nullable<int> CurrentCount
		{
			get
			{
				return this._CurrentCount;
			}
			set
			{
				if ((this._CurrentCount != value))
				{
					this.OnCurrentCountChanging(value);
					this.SendPropertyChanging();
					this._CurrentCount = value;
					this.SendPropertyChanged("CurrentCount");
					this.OnCurrentCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderStatus", DbType="VarChar(50)")]
		public string OrderStatus
		{
			get
			{
				return this._OrderStatus;
			}
			set
			{
				if ((this._OrderStatus != value))
				{
					this.OnOrderStatusChanging(value);
					this.SendPropertyChanging();
					this._OrderStatus = value;
					this.SendPropertyChanged("OrderStatus");
					this.OnOrderStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastUpdateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastUpdateDate
		{
			get
			{
				return this._LastUpdateDate;
			}
			set
			{
				if ((this._LastUpdateDate != value))
				{
					this.OnLastUpdateDateChanging(value);
					this.SendPropertyChanging();
					this._LastUpdateDate = value;
					this.SendPropertyChanged("LastUpdateDate");
					this.OnLastUpdateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderType", DbType="VarChar(50)")]
		public string OrderType
		{
			get
			{
				return this._OrderType;
			}
			set
			{
				if ((this._OrderType != value))
				{
					this.OnOrderTypeChanging(value);
					this.SendPropertyChanging();
					this._OrderType = value;
					this.SendPropertyChanged("OrderType");
					this.OnOrderTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="C325018_IGPanel.tblPlan")]
	public partial class tblPlan : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PlanId;
		
		private string _PlanName;
		
		private System.Nullable<int> _LikeAmount;
		
		private System.Nullable<int> _MaxPhotos;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPlanIdChanging(int value);
    partial void OnPlanIdChanged();
    partial void OnPlanNameChanging(string value);
    partial void OnPlanNameChanged();
    partial void OnLikeAmountChanging(System.Nullable<int> value);
    partial void OnLikeAmountChanged();
    partial void OnMaxPhotosChanging(System.Nullable<int> value);
    partial void OnMaxPhotosChanged();
    #endregion
		
		public tblPlan()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlanId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PlanId
		{
			get
			{
				return this._PlanId;
			}
			set
			{
				if ((this._PlanId != value))
				{
					this.OnPlanIdChanging(value);
					this.SendPropertyChanging();
					this._PlanId = value;
					this.SendPropertyChanged("PlanId");
					this.OnPlanIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlanName", DbType="VarChar(50)")]
		public string PlanName
		{
			get
			{
				return this._PlanName;
			}
			set
			{
				if ((this._PlanName != value))
				{
					this.OnPlanNameChanging(value);
					this.SendPropertyChanging();
					this._PlanName = value;
					this.SendPropertyChanged("PlanName");
					this.OnPlanNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LikeAmount", DbType="Int")]
		public System.Nullable<int> LikeAmount
		{
			get
			{
				return this._LikeAmount;
			}
			set
			{
				if ((this._LikeAmount != value))
				{
					this.OnLikeAmountChanging(value);
					this.SendPropertyChanging();
					this._LikeAmount = value;
					this.SendPropertyChanged("LikeAmount");
					this.OnLikeAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaxPhotos", DbType="Int")]
		public System.Nullable<int> MaxPhotos
		{
			get
			{
				return this._MaxPhotos;
			}
			set
			{
				if ((this._MaxPhotos != value))
				{
					this.OnMaxPhotosChanging(value);
					this.SendPropertyChanging();
					this._MaxPhotos = value;
					this.SendPropertyChanged("MaxPhotos");
					this.OnMaxPhotosChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="C325018_IGPanel.tbl_CutomerDetail")]
	public partial class tbl_CutomerDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _CutomerId;
		
		private string _InstagramUserName;
		
		private string _Planid;
		
		private string _Status;
		
		private string _OrderDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCutomerIdChanging(string value);
    partial void OnCutomerIdChanged();
    partial void OnInstagramUserNameChanging(string value);
    partial void OnInstagramUserNameChanged();
    partial void OnPlanidChanging(string value);
    partial void OnPlanidChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    partial void OnOrderDateChanging(string value);
    partial void OnOrderDateChanged();
    #endregion
		
		public tbl_CutomerDetail()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CutomerId", DbType="VarChar(500)")]
		public string CutomerId
		{
			get
			{
				return this._CutomerId;
			}
			set
			{
				if ((this._CutomerId != value))
				{
					this.OnCutomerIdChanging(value);
					this.SendPropertyChanging();
					this._CutomerId = value;
					this.SendPropertyChanged("CutomerId");
					this.OnCutomerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstagramUserName", DbType="VarChar(500)")]
		public string InstagramUserName
		{
			get
			{
				return this._InstagramUserName;
			}
			set
			{
				if ((this._InstagramUserName != value))
				{
					this.OnInstagramUserNameChanging(value);
					this.SendPropertyChanging();
					this._InstagramUserName = value;
					this.SendPropertyChanged("InstagramUserName");
					this.OnInstagramUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Planid", DbType="VarChar(50)")]
		public string Planid
		{
			get
			{
				return this._Planid;
			}
			set
			{
				if ((this._Planid != value))
				{
					this.OnPlanidChanging(value);
					this.SendPropertyChanging();
					this._Planid = value;
					this.SendPropertyChanged("Planid");
					this.OnPlanidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="VarChar(50)")]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderDate", DbType="VarChar(500)")]
		public string OrderDate
		{
			get
			{
				return this._OrderDate;
			}
			set
			{
				if ((this._OrderDate != value))
				{
					this.OnOrderDateChanging(value);
					this.SendPropertyChanging();
					this._OrderDate = value;
					this.SendPropertyChanged("OrderDate");
					this.OnOrderDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
