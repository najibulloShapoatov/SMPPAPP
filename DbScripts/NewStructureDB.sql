

create table if not exists "UserTypes"(
    "Id" bigserial not null primary key,
    "Name" varchar(50) not null unique,
    "Note" text,
    "IsActive" boolean not null default(TRUE),
    "CreatedAt" timestamp without time zone not null default(current_timestamp),
    "UpdatedAt" timestamp without time zone not null default(current_timestamp)
);

create table if not exists "Users"(
    "Id" bigserial primary key,
    "UserType" varchar(50) not  null references "UserTypes"("Name"),
    "UserName" varchar(255) unique,
    "Password" varchar(500),
    "Name" varchar(255) ,
    "Image" varchar(255) ,
    "APIKey" varchar(255),
    "IsActive" boolean not null default(TRUE),
    "CreatedAt" timestamp without time zone not null default(current_timestamp),
    "UpdatedAt" timestamp without time zone not null default(current_timestamp)
);


create table if not exists "Alphanumerics"(
    "Id" bigserial primary key,
    "Name" varchar(255) not null unique,
    "IsActive" boolean not null default(TRUE),
    "CreatedAt" timestamp without time zone not null default(current_timestamp),
    "UpdatedAt" timestamp without time zone not null default(current_timestamp)
);


create table if not exists "AlphanumericAccess"(
    "Id" bigserial primary key,
    "Alphanumeric" varchar(255) not  null references "Alphanumerics"("Name"),
    "UserId" int8 not  null references "Users"("Id"),
    "IsActive" boolean not null default(TRUE),
    "CreatedAt" timestamp without time zone not null default(current_timestamp),
    "UpdatedAt" timestamp without time zone not null default(current_timestamp)
);


create table if not exists "SentSms"(
    "Id" bigserial primary key, 
    "Alphanumeric" varchar(255) not  null references "Alphanumerics"("Name"),
    "UserId" int8 not  null references "Users"("Id"),
    "Parts" int4 not  null default(1),
    "Phone" varchar(50) not null,
    "Content" text,
    "Note" text,
	"IsActive" boolean not null default(TRUE),
    "CreatedAt" timestamp without time zone not null default(current_timestamp),
    "UpdatedAt" timestamp without time zone not null default(current_timestamp)
);



create table if not exists "SentSmsPart"(
    "Id" bigserial primary key,
    "IsActive" boolean not null default(TRUE),
    "SentSmsId" int8 not  null references "SentSms"("Id"),
    "OutsideId" varchar(1024),
    "Note" text,
    "CreatedAt" timestamp without time zone not null default(current_timestamp),
    "UpdatedAt" timestamp without time zone not null default(current_timestamp)
);
