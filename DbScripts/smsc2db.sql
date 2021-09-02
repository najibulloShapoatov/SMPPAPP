/*
 Navicat Premium Data Transfer

 Source Server         : postgre
 Source Server Type    : PostgreSQL
 Source Server Version : 130000
 Source Host           : localhost:5432
 Source Catalog        : smsc2db
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 130000
 File Encoding         : 65001

 Date: 14/06/2021 15:54:15
*/


-- ----------------------------
-- Sequence structure for Alphanumerics_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Alphanumerics_Id_seq";
CREATE SEQUENCE "public"."Alphanumerics_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for SentSmsPart_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."SentSmsPart_Id_seq";
CREATE SEQUENCE "public"."SentSmsPart_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for SentSms_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."SentSms_Id_seq";
CREATE SEQUENCE "public"."SentSms_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for UserTypes_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."UserTypes_Id_seq";
CREATE SEQUENCE "public"."UserTypes_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for Users_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."Users_Id_seq";
CREATE SEQUENCE "public"."Users_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for alphanumeric_accessess_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."alphanumeric_accessess_id_seq";
CREATE SEQUENCE "public"."alphanumeric_accessess_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for queues_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."queues_id_seq";
CREATE SEQUENCE "public"."queues_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

-- ----------------------------
-- Table structure for _queues
-- ----------------------------
DROP TABLE IF EXISTS "public"."_queues";
CREATE TABLE "public"."_queues" (
  "id" int8 NOT NULL,
  "priority" int2 NOT NULL DEFAULT 0,
  "type" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "message_id" int8 NOT NULL,
  "is_active" bool NOT NULL,
  "created_at" timestamp(6) NOT NULL,
  "updated_at" timestamp(6) NOT NULL
)
;

-- ----------------------------
-- Table structure for alphanumeric_accesses
-- ----------------------------
DROP TABLE IF EXISTS "public"."alphanumeric_accesses";
CREATE TABLE "public"."alphanumeric_accesses" (
  "id" int8 NOT NULL DEFAULT nextval('alphanumeric_accessess_id_seq'::regclass),
  "alphanumeric_id" int8 NOT NULL,
  "user_id" int8 NOT NULL,
  "IsActive" bool NOT NULL DEFAULT true,
  "CreatedAt" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "UpdatedAt" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Table structure for alphanumerics
-- ----------------------------
DROP TABLE IF EXISTS "public"."alphanumerics";
CREATE TABLE "public"."alphanumerics" (
  "id" int8 NOT NULL DEFAULT nextval('"Alphanumerics_Id_seq"'::regclass),
  "name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "is_active" bool NOT NULL DEFAULT true,
  "created_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "updated_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Table structure for message_parts
-- ----------------------------
DROP TABLE IF EXISTS "public"."message_parts";
CREATE TABLE "public"."message_parts" (
  "id" int8 NOT NULL DEFAULT nextval('"SentSmsPart_Id_seq"'::regclass),
  "is_active" bool NOT NULL DEFAULT true,
  "message_id" int8 NOT NULL,
  "outside_id" varchar(1024) COLLATE "pg_catalog"."default",
  "note" text COLLATE "pg_catalog"."default",
  "created_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "updated_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Table structure for messages
-- ----------------------------
DROP TABLE IF EXISTS "public"."messages";
CREATE TABLE "public"."messages" (
  "id" int8 NOT NULL DEFAULT nextval('"SentSms_Id_seq"'::regclass),
  "alphanumeric" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "user_id" int8 NOT NULL,
  "parts" int4 DEFAULT 1,
  "phone" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "content" text COLLATE "pg_catalog"."default",
  "note" varchar(255) COLLATE "pg_catalog"."default",
  "is_active" bool NOT NULL DEFAULT true,
  "created_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "updated_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "scheduled_at" timestamp(6),
  "sent_at" timestamp(6),
  "status" int2 DEFAULT 1
)
;

-- ----------------------------
-- Table structure for queues
-- ----------------------------
DROP TABLE IF EXISTS "public"."queues";
CREATE TABLE "public"."queues" (
  "id" int8 NOT NULL DEFAULT nextval('queues_id_seq'::regclass),
  "priority" int2 NOT NULL DEFAULT 0,
  "type" varchar(255) COLLATE "pg_catalog"."default",
  "message_id" int8 NOT NULL,
  "is_active" bool NOT NULL DEFAULT true,
  "created_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "updated_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Table structure for user_types
-- ----------------------------
DROP TABLE IF EXISTS "public"."user_types";
CREATE TABLE "public"."user_types" (
  "id" int8 NOT NULL DEFAULT nextval('"UserTypes_Id_seq"'::regclass),
  "name" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "note" text COLLATE "pg_catalog"."default",
  "is_active" bool NOT NULL DEFAULT true,
  "created_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "updated_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS "public"."users";
CREATE TABLE "public"."users" (
  "id" int8 NOT NULL DEFAULT nextval('"Users_Id_seq"'::regclass),
  "user_type" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "username" varchar(255) COLLATE "pg_catalog"."default",
  "password" varchar(500) COLLATE "pg_catalog"."default",
  "name" varchar(255) COLLATE "pg_catalog"."default",
  "image" varchar(255) COLLATE "pg_catalog"."default",
  "api_key" varchar(255) COLLATE "pg_catalog"."default",
  "is_active" bool NOT NULL DEFAULT true,
  "created_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "updated_at" timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Alphanumerics_Id_seq"
OWNED BY "public"."alphanumerics"."id";
SELECT setval('"public"."Alphanumerics_Id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."SentSmsPart_Id_seq"
OWNED BY "public"."message_parts"."id";
SELECT setval('"public"."SentSmsPart_Id_seq"', 2, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."SentSms_Id_seq"
OWNED BY "public"."messages"."id";
SELECT setval('"public"."SentSms_Id_seq"', 12, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."UserTypes_Id_seq"
OWNED BY "public"."user_types"."id";
SELECT setval('"public"."UserTypes_Id_seq"', 4, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."Users_Id_seq"
OWNED BY "public"."users"."id";
SELECT setval('"public"."Users_Id_seq"', 3, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."alphanumeric_accessess_id_seq"
OWNED BY "public"."alphanumeric_accesses"."id";
SELECT setval('"public"."alphanumeric_accessess_id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."queues_id_seq"
OWNED BY "public"."queues"."id";
SELECT setval('"public"."queues_id_seq"', 11, true);

-- ----------------------------
-- Primary Key structure for table _queues
-- ----------------------------
ALTER TABLE "public"."_queues" ADD CONSTRAINT "Queue_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table alphanumeric_accesses
-- ----------------------------
ALTER TABLE "public"."alphanumeric_accesses" ADD CONSTRAINT "alphanumeric_accessess_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Uniques structure for table alphanumerics
-- ----------------------------
ALTER TABLE "public"."alphanumerics" ADD CONSTRAINT "Alphanumerics_Name_key" UNIQUE ("name");

-- ----------------------------
-- Primary Key structure for table alphanumerics
-- ----------------------------
ALTER TABLE "public"."alphanumerics" ADD CONSTRAINT "Alphanumerics_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table message_parts
-- ----------------------------
ALTER TABLE "public"."message_parts" ADD CONSTRAINT "SentSmsPart_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table messages
-- ----------------------------
ALTER TABLE "public"."messages" ADD CONSTRAINT "SentSms_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table queues
-- ----------------------------
ALTER TABLE "public"."queues" ADD CONSTRAINT "queues_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Uniques structure for table user_types
-- ----------------------------
ALTER TABLE "public"."user_types" ADD CONSTRAINT "UserTypes_Name_key" UNIQUE ("name");

-- ----------------------------
-- Primary Key structure for table user_types
-- ----------------------------
ALTER TABLE "public"."user_types" ADD CONSTRAINT "UserTypes_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Uniques structure for table users
-- ----------------------------
ALTER TABLE "public"."users" ADD CONSTRAINT "Users_UserName_key" UNIQUE ("username");

-- ----------------------------
-- Primary Key structure for table users
-- ----------------------------
ALTER TABLE "public"."users" ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Foreign Keys structure for table alphanumeric_accesses
-- ----------------------------
ALTER TABLE "public"."alphanumeric_accesses" ADD CONSTRAINT "alphanumeric_accessess_alphanumeric_id_fkey" FOREIGN KEY ("alphanumeric_id") REFERENCES "public"."alphanumerics" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."alphanumeric_accesses" ADD CONSTRAINT "alphanumeric_accessess_user_id_fkey" FOREIGN KEY ("user_id") REFERENCES "public"."users" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table message_parts
-- ----------------------------
ALTER TABLE "public"."message_parts" ADD CONSTRAINT "SentSmsPart_SentSmsId_fkey" FOREIGN KEY ("message_id") REFERENCES "public"."messages" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table messages
-- ----------------------------
ALTER TABLE "public"."messages" ADD CONSTRAINT "SentSms_Alphanumeric_fkey" FOREIGN KEY ("alphanumeric") REFERENCES "public"."alphanumerics" ("name") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."messages" ADD CONSTRAINT "SentSms_UserId_fkey" FOREIGN KEY ("user_id") REFERENCES "public"."users" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table users
-- ----------------------------
ALTER TABLE "public"."users" ADD CONSTRAINT "Users_UserType_fkey" FOREIGN KEY ("user_type") REFERENCES "public"."user_types" ("name") ON DELETE NO ACTION ON UPDATE NO ACTION;
