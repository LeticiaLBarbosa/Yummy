﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YummyApp
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="yummyDatabase")]
	public partial class yummyDatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertIngredient(Ingredient instance);
    partial void UpdateIngredient(Ingredient instance);
    partial void DeleteIngredient(Ingredient instance);
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    partial void InsertRecipeIngredient(RecipeIngredient instance);
    partial void UpdateRecipeIngredient(RecipeIngredient instance);
    partial void DeleteRecipeIngredient(RecipeIngredient instance);
    partial void InsertUserRecipe(UserRecipe instance);
    partial void UpdateUserRecipe(UserRecipe instance);
    partial void DeleteUserRecipe(UserRecipe instance);
    partial void InsertRecipe(Recipe instance);
    partial void UpdateRecipe(Recipe instance);
    partial void DeleteRecipe(Recipe instance);
    #endregion
		
		public yummyDatabaseDataContext() : 
				base(global::YummyApp.Properties.Settings.Default.yummyDatabaseConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public yummyDatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public yummyDatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public yummyDatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public yummyDatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Ingredient> Ingredients
		{
			get
			{
				return this.GetTable<Ingredient>();
			}
		}
		
		public System.Data.Linq.Table<Recipe> Recipes
		{
			get
			{
				return this.GetTable<Recipe>();
			}
		}
		
		public System.Data.Linq.Table<RecipeIngredient> RecipeIngredients
		{
			get
			{
				return this.GetTable<RecipeIngredient>();
			}
		}
		
		public System.Data.Linq.Table<UserRecipe> UserRecipes
		{
			get
			{
				return this.GetTable<UserRecipe>();
			}
		}
		
		public System.Data.Linq.Table<Category> Categories
		{
			get
			{
				return this.GetTable<Category>();
			}
		}

     

       
    }
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Ingredient")]
	public partial class Ingredient : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IngredientId;
		
		private string _Name;
		
		private EntitySet<RecipeIngredient> _RecipeIngredients;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIngredientIdChanging(int value);
    partial void OnIngredientIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Ingredient()
		{
			this._RecipeIngredients = new EntitySet<RecipeIngredient>(new Action<RecipeIngredient>(this.attach_RecipeIngredients), new Action<RecipeIngredient>(this.detach_RecipeIngredients));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IngredientId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IngredientId
		{
			get
			{
				return this._IngredientId;
			}
			set
			{
				if ((this._IngredientId != value))
				{
					this.OnIngredientIdChanging(value);
					this.SendPropertyChanging();
					this._IngredientId = value;
					this.SendPropertyChanged("IngredientId");
					this.OnIngredientIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Ingredient_RecipeIngredient", Storage="_RecipeIngredients", ThisKey="IngredientId", OtherKey="IngredientId")]
		public EntitySet<RecipeIngredient> RecipeIngredients
		{
			get
			{
				return this._RecipeIngredients;
			}
			set
			{
				this._RecipeIngredients.Assign(value);
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
		
		private void attach_RecipeIngredients(RecipeIngredient entity)
		{
			this.SendPropertyChanging();
			entity.Ingredient = this;
		}
		
		private void detach_RecipeIngredients(RecipeIngredient entity)
		{
			this.SendPropertyChanging();
			entity.Ingredient = null;
		}
	}

	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.RecipeIngredient")]
	public partial class RecipeIngredient : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _RecipeId;
		
		private int _IngredientId;
		
		private double _Quantity;
		
		private string _Measurement;
		
		private EntityRef<Ingredient> _Ingredient;
		
		private EntityRef<Recipe> _Recipe1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnRecipeIdChanging(int value);
    partial void OnRecipeIdChanged();
    partial void OnIngredientIdChanging(int value);
    partial void OnIngredientIdChanged();
    partial void OnQuantityChanging(double value);
    partial void OnQuantityChanged();
    partial void OnMeasurementChanging(string value);
    partial void OnMeasurementChanged();
    #endregion
		
		public RecipeIngredient()
		{
			this._Ingredient = default(EntityRef<Ingredient>);
			this._Recipe1 = default(EntityRef<Recipe>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecipeId", DbType="Int NOT NULL")]
		public int RecipeId
		{
			get
			{
				return this._RecipeId;
			}
			set
			{
				if ((this._RecipeId != value))
				{
					if (this._Recipe1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRecipeIdChanging(value);
					this.SendPropertyChanging();
					this._RecipeId = value;
					this.SendPropertyChanged("RecipeId");
					this.OnRecipeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IngredientId", DbType="Int NOT NULL")]
		public int IngredientId
		{
			get
			{
				return this._IngredientId;
			}
			set
			{
				if ((this._IngredientId != value))
				{
					if (this._Ingredient.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIngredientIdChanging(value);
					this.SendPropertyChanging();
					this._IngredientId = value;
					this.SendPropertyChanged("IngredientId");
					this.OnIngredientIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Float NOT NULL")]
		public double Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Measurement", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Measurement
		{
			get
			{
				return this._Measurement;
			}
			set
			{
				if ((this._Measurement != value))
				{
					this.OnMeasurementChanging(value);
					this.SendPropertyChanging();
					this._Measurement = value;
					this.SendPropertyChanged("Measurement");
					this.OnMeasurementChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Ingredient_RecipeIngredient", Storage="_Ingredient", ThisKey="IngredientId", OtherKey="IngredientId", IsForeignKey=true)]
		public Ingredient Ingredient
		{
			get
			{
				return this._Ingredient.Entity;
			}
			set
			{
				Ingredient previousValue = this._Ingredient.Entity;
				if (((previousValue != value) 
							|| (this._Ingredient.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Ingredient.Entity = null;
						previousValue.RecipeIngredients.Remove(this);
					}
					this._Ingredient.Entity = value;
					if ((value != null))
					{
						value.RecipeIngredients.Add(this);
						this._IngredientId = value.IngredientId;
					}
					else
					{
						this._IngredientId = default(int);
					}
					this.SendPropertyChanged("Ingredient");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Recipe_RecipeIngredient", Storage="_Recipe1", ThisKey="RecipeId", OtherKey="RecipeId", IsForeignKey=true)]
		public Recipe Recipe
		{
			get
			{
				return this._Recipe1.Entity;
			}
			set
			{
				Recipe previousValue = this._Recipe1.Entity;
				if (((previousValue != value) 
							|| (this._Recipe1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Recipe1.Entity = null;
						previousValue.RecipeIngredients.Remove(this);
					}
					this._Recipe1.Entity = value;
					if ((value != null))
					{
						value.RecipeIngredients.Add(this);
						this._RecipeId = value.RecipeId;
					}
					else
					{
						this._RecipeId = default(int);
					}
					this.SendPropertyChanged("Recipe");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserRecipe")]
	public partial class UserRecipe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserRecipeId;
		
		private int _UserId;
		
		private int _RecipeId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserRecipeIdChanging(int value);
    partial void OnUserRecipeIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnRecipeIdChanging(int value);
    partial void OnRecipeIdChanged();
    #endregion
		
		public UserRecipe()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserRecipeId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserRecipeId
		{
			get
			{
				return this._UserRecipeId;
			}
			set
			{
				if ((this._UserRecipeId != value))
				{
					this.OnUserRecipeIdChanging(value);
					this.SendPropertyChanging();
					this._UserRecipeId = value;
					this.SendPropertyChanged("UserRecipeId");
					this.OnUserRecipeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecipeId", DbType="Int NOT NULL")]
		public int RecipeId
		{
			get
			{
				return this._RecipeId;
			}
			set
			{
				if ((this._RecipeId != value))
				{
					this.OnRecipeIdChanging(value);
					this.SendPropertyChanging();
					this._RecipeId = value;
					this.SendPropertyChanged("RecipeId");
					this.OnRecipeIdChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Recipe")]
	public partial class Recipe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RecipeId;
		
		private string _Name;
		
		private System.Nullable<int> _Serving;
		
		private System.Nullable<int> _PrepTime;
		
		private string _Directions;
		
		private int _Category;
		
		private System.Data.Linq.Binary _Image;
		
		private string _Description;
		
		private EntitySet<RecipeIngredient> _RecipeIngredients;
		
		private EntityRef<Category> _Category1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRecipeIdChanging(int value);
    partial void OnRecipeIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnServingChanging(System.Nullable<int> value);
    partial void OnServingChanged();
    partial void OnPrepTimeChanging(System.Nullable<int> value);
    partial void OnPrepTimeChanged();
    partial void OnDirectionsChanging(string value);
    partial void OnDirectionsChanged();
    partial void OnCategoryChanging(int value);
    partial void OnCategoryChanged();
    partial void OnImageChanging(System.Data.Linq.Binary value);
    partial void OnImageChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Recipe()
		{
			this._RecipeIngredients = new EntitySet<RecipeIngredient>(new Action<RecipeIngredient>(this.attach_RecipeIngredients), new Action<RecipeIngredient>(this.detach_RecipeIngredients));
			this._Category1 = default(EntityRef<Category>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecipeId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int RecipeId
		{
			get
			{
				return this._RecipeId;
			}
			set
			{
				if ((this._RecipeId != value))
				{
					this.OnRecipeIdChanging(value);
					this.SendPropertyChanging();
					this._RecipeId = value;
					this.SendPropertyChanged("RecipeId");
					this.OnRecipeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(200)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Serving", DbType="Int")]
		public System.Nullable<int> Serving
		{
			get
			{
				return this._Serving;
			}
			set
			{
				if ((this._Serving != value))
				{
					this.OnServingChanging(value);
					this.SendPropertyChanging();
					this._Serving = value;
					this.SendPropertyChanged("Serving");
					this.OnServingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrepTime", DbType="Int")]
		public System.Nullable<int> PrepTime
		{
			get
			{
				return this._PrepTime;
			}
			set
			{
				if ((this._PrepTime != value))
				{
					this.OnPrepTimeChanging(value);
					this.SendPropertyChanging();
					this._PrepTime = value;
					this.SendPropertyChanged("PrepTime");
					this.OnPrepTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Directions", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Directions
		{
			get
			{
				return this._Directions;
			}
			set
			{
				if ((this._Directions != value))
				{
					this.OnDirectionsChanging(value);
					this.SendPropertyChanging();
					this._Directions = value;
					this.SendPropertyChanged("Directions");
					this.OnDirectionsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="Int NOT NULL")]
		public int Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					if (this._Category1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Recipe_RecipeIngredient", Storage="_RecipeIngredients", ThisKey="RecipeId", OtherKey="RecipeId")]
		public EntitySet<RecipeIngredient> RecipeIngredients
		{
			get
			{
				return this._RecipeIngredients;
			}
			set
			{
				this._RecipeIngredients.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Recipe", Storage="_Category1", ThisKey="Category", OtherKey="CategoryId", IsForeignKey=true)]
		public Category Category1
		{
			get
			{
				return this._Category1.Entity;
			}
			set
			{
				Category previousValue = this._Category1.Entity;
				if (((previousValue != value) 
							|| (this._Category1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Category1.Entity = null;
						previousValue.Recipes.Remove(this);
					}
					this._Category1.Entity = value;
					if ((value != null))
					{
						value.Recipes.Add(this);
						this._Category = value.CategoryId;
					}
					else
					{
						this._Category = default(int);
					}
					this.SendPropertyChanged("Category1");
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
		
		private void attach_RecipeIngredients(RecipeIngredient entity)
		{
			this.SendPropertyChanging();
			entity.Recipe = this;
		}
		
		private void detach_RecipeIngredients(RecipeIngredient entity)
		{
			this.SendPropertyChanging();
			entity.Recipe = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Category")]
	public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CategoryId;
		
		private string _CategoryName;
		
		private System.Data.Linq.Binary _CategoryImage;
		
		private System.Nullable<System.DateTime> _ModifyDate;
		
		private EntitySet<Recipe> _Recipes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCategoryIdChanging(int value);
    partial void OnCategoryIdChanged();
    partial void OnCategoryNameChanging(string value);
    partial void OnCategoryNameChanged();
    partial void OnCategoryImageChanging(System.Data.Linq.Binary value);
    partial void OnCategoryImageChanged();
    partial void OnModifyDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifyDateChanged();
    #endregion
		
		public Category()
		{
			this._Recipes = new EntitySet<Recipe>(new Action<Recipe>(this.attach_Recipes), new Action<Recipe>(this.detach_Recipes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CategoryId
		{
			get
			{
				return this._CategoryId;
			}
			set
			{
				if ((this._CategoryId != value))
				{
					this.OnCategoryIdChanging(value);
					this.SendPropertyChanging();
					this._CategoryId = value;
					this.SendPropertyChanged("CategoryId");
					this.OnCategoryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string CategoryName
		{
			get
			{
				return this._CategoryName;
			}
			set
			{
				if ((this._CategoryName != value))
				{
					this.OnCategoryNameChanging(value);
					this.SendPropertyChanging();
					this._CategoryName = value;
					this.SendPropertyChanged("CategoryName");
					this.OnCategoryNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryImage", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary CategoryImage
		{
			get
			{
				return this._CategoryImage;
			}
			set
			{
				if ((this._CategoryImage != value))
				{
					this.OnCategoryImageChanging(value);
					this.SendPropertyChanging();
					this._CategoryImage = value;
					this.SendPropertyChanged("CategoryImage");
					this.OnCategoryImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				if ((this._ModifyDate != value))
				{
					this.OnModifyDateChanging(value);
					this.SendPropertyChanging();
					this._ModifyDate = value;
					this.SendPropertyChanged("ModifyDate");
					this.OnModifyDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Recipe", Storage="_Recipes", ThisKey="CategoryId", OtherKey="Category")]
		public EntitySet<Recipe> Recipes
		{
			get
			{
				return this._Recipes;
			}
			set
			{
				this._Recipes.Assign(value);
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
		
		private void attach_Recipes(Recipe entity)
		{
			this.SendPropertyChanging();
			entity.Category1 = this;
		}
		
		private void detach_Recipes(Recipe entity)
		{
			this.SendPropertyChanging();
			entity.Category1 = null;
		}
	}
}
#pragma warning restore 1591
