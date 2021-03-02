export type Maybe<T> = T | null;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  Decimal: any;
  Upload: any;
};

export type BooleanOperationFilterInput = {
  eq?: Maybe<Scalars['Boolean']>;
  neq?: Maybe<Scalars['Boolean']>;
};

export enum CacheControlScope {
  Public = 'PUBLIC',
  Private = 'PRIVATE'
}

export type ComparableDecimalOperationFilterInput = {
  eq?: Maybe<Scalars['Decimal']>;
  neq?: Maybe<Scalars['Decimal']>;
  in?: Maybe<Array<Scalars['Decimal']>>;
  nin?: Maybe<Array<Scalars['Decimal']>>;
  gt?: Maybe<Scalars['Decimal']>;
  ngt?: Maybe<Scalars['Decimal']>;
  gte?: Maybe<Scalars['Decimal']>;
  ngte?: Maybe<Scalars['Decimal']>;
  lt?: Maybe<Scalars['Decimal']>;
  nlt?: Maybe<Scalars['Decimal']>;
  lte?: Maybe<Scalars['Decimal']>;
  nlte?: Maybe<Scalars['Decimal']>;
};

export type ComparableInt32OperationFilterInput = {
  eq?: Maybe<Scalars['Int']>;
  neq?: Maybe<Scalars['Int']>;
  in?: Maybe<Array<Scalars['Int']>>;
  nin?: Maybe<Array<Scalars['Int']>>;
  gt?: Maybe<Scalars['Int']>;
  ngt?: Maybe<Scalars['Int']>;
  gte?: Maybe<Scalars['Int']>;
  ngte?: Maybe<Scalars['Int']>;
  lt?: Maybe<Scalars['Int']>;
  nlt?: Maybe<Scalars['Int']>;
  lte?: Maybe<Scalars['Int']>;
  nlte?: Maybe<Scalars['Int']>;
};

export type CreatePropertyInput = {
  name?: Maybe<Scalars['String']>;
  city?: Maybe<Scalars['String']>;
  street?: Maybe<Scalars['String']>;
  spa: Scalars['Boolean'];
  swimmingPool: Scalars['Boolean'];
};

export type CreateTrulloInput = {
  name?: Maybe<Scalars['String']>;
  description?: Maybe<Scalars['String']>;
  capacity: Scalars['Int'];
  price: Scalars['Decimal'];
  propertyId?: Maybe<Scalars['ID']>;
};


export type DeleteTrulloInput = {
  id: Scalars['ID'];
};

export type ListFilterInputTypeOfTrulloFilterInput = {
  all?: Maybe<TrulloFilterInput>;
  none?: Maybe<TrulloFilterInput>;
  some?: Maybe<TrulloFilterInput>;
  any?: Maybe<Scalars['Boolean']>;
};

export type Mutation = {
  __typename?: 'Mutation';
  createTrullo?: Maybe<Trullo>;
  deleteTrullo?: Maybe<Trullo>;
  createProperty?: Maybe<Property>;
};


export type MutationCreateTrulloArgs = {
  trullo?: Maybe<CreateTrulloInput>;
};


export type MutationDeleteTrulloArgs = {
  deletedTrullo?: Maybe<DeleteTrulloInput>;
};


export type MutationCreatePropertyArgs = {
  property?: Maybe<CreatePropertyInput>;
};

export type PageInfo = {
  __typename?: 'PageInfo';
  hasNextPage: Scalars['Boolean'];
  hasPreviousPage: Scalars['Boolean'];
  startCursor?: Maybe<Scalars['String']>;
  endCursor?: Maybe<Scalars['String']>;
};

export type Property = {
  __typename?: 'Property';
  _id: Scalars['ID'];
  name?: Maybe<Scalars['String']>;
  city?: Maybe<Scalars['String']>;
  street?: Maybe<Scalars['String']>;
  spa: Scalars['Boolean'];
  swimmingPool: Scalars['Boolean'];
  trulli?: Maybe<Array<Maybe<Trullo>>>;
};

export type PropertyConnection = {
  __typename?: 'PropertyConnection';
  pageInfo: PageInfo;
  edges?: Maybe<Array<PropertyEdge>>;
  nodes?: Maybe<Array<Maybe<Property>>>;
};

export type PropertyEdge = {
  __typename?: 'PropertyEdge';
  cursor: Scalars['String'];
  node?: Maybe<Property>;
};

export type PropertyFilterInput = {
  and?: Maybe<Array<PropertyFilterInput>>;
  or?: Maybe<Array<PropertyFilterInput>>;
  _id?: Maybe<StringOperationFilterInput>;
  name?: Maybe<StringOperationFilterInput>;
  city?: Maybe<StringOperationFilterInput>;
  street?: Maybe<StringOperationFilterInput>;
  spa?: Maybe<BooleanOperationFilterInput>;
  swimmingPool?: Maybe<BooleanOperationFilterInput>;
  trulli?: Maybe<ListFilterInputTypeOfTrulloFilterInput>;
};

export type PropertySortInput = {
  _id?: Maybe<SortEnumType>;
  name?: Maybe<SortEnumType>;
  city?: Maybe<SortEnumType>;
  street?: Maybe<SortEnumType>;
  spa?: Maybe<SortEnumType>;
  swimmingPool?: Maybe<SortEnumType>;
};

export type Query = {
  __typename?: 'Query';
  properties?: Maybe<PropertyConnection>;
  trulloById?: Maybe<Trullo>;
  trulli?: Maybe<TrulloConnection>;
};


export type QueryPropertiesArgs = {
  first?: Maybe<Scalars['Int']>;
  after?: Maybe<Scalars['String']>;
  last?: Maybe<Scalars['Int']>;
  before?: Maybe<Scalars['String']>;
  where?: Maybe<PropertyFilterInput>;
  order?: Maybe<Array<PropertySortInput>>;
};


export type QueryTrulloByIdArgs = {
  id?: Maybe<Scalars['String']>;
};


export type QueryTrulliArgs = {
  first?: Maybe<Scalars['Int']>;
  after?: Maybe<Scalars['String']>;
  last?: Maybe<Scalars['Int']>;
  before?: Maybe<Scalars['String']>;
  where?: Maybe<TrulloFilterInput>;
  order?: Maybe<Array<TrulloSortInput>>;
};

export enum SortEnumType {
  Asc = 'ASC',
  Desc = 'DESC'
}

export type StringOperationFilterInput = {
  and?: Maybe<Array<StringOperationFilterInput>>;
  or?: Maybe<Array<StringOperationFilterInput>>;
  eq?: Maybe<Scalars['String']>;
  neq?: Maybe<Scalars['String']>;
  contains?: Maybe<Scalars['String']>;
  ncontains?: Maybe<Scalars['String']>;
  in?: Maybe<Array<Maybe<Scalars['String']>>>;
  nin?: Maybe<Array<Maybe<Scalars['String']>>>;
  startsWith?: Maybe<Scalars['String']>;
  nstartsWith?: Maybe<Scalars['String']>;
  endsWith?: Maybe<Scalars['String']>;
  nendsWith?: Maybe<Scalars['String']>;
};

export type Subscription = {
  __typename?: 'Subscription';
  onTrulloCreate?: Maybe<Trullo>;
  onTrulloGet?: Maybe<Trullo>;
};

export type Trullo = {
  __typename?: 'Trullo';
  _id: Scalars['ID'];
  property_id: Scalars['ID'];
  name?: Maybe<Scalars['String']>;
  description?: Maybe<Scalars['String']>;
  capacity: Scalars['Int'];
  price: Scalars['Decimal'];
};

export type TrulloConnection = {
  __typename?: 'TrulloConnection';
  pageInfo: PageInfo;
  edges?: Maybe<Array<TrulloEdge>>;
  nodes?: Maybe<Array<Maybe<Trullo>>>;
};

export type TrulloEdge = {
  __typename?: 'TrulloEdge';
  cursor: Scalars['String'];
  node?: Maybe<Trullo>;
};

export type TrulloFilterInput = {
  and?: Maybe<Array<TrulloFilterInput>>;
  or?: Maybe<Array<TrulloFilterInput>>;
  _id?: Maybe<StringOperationFilterInput>;
  property_id?: Maybe<StringOperationFilterInput>;
  name?: Maybe<StringOperationFilterInput>;
  description?: Maybe<StringOperationFilterInput>;
  capacity?: Maybe<ComparableInt32OperationFilterInput>;
  price?: Maybe<ComparableDecimalOperationFilterInput>;
};

export type TrulloSortInput = {
  _id?: Maybe<SortEnumType>;
  property_id?: Maybe<SortEnumType>;
  name?: Maybe<SortEnumType>;
  description?: Maybe<SortEnumType>;
  capacity?: Maybe<SortEnumType>;
  price?: Maybe<SortEnumType>;
};

