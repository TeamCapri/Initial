--------------------------------------------------------
--  File created - Wednesday-July-29-2015   
--------------------------------------------------------
DROP TABLE "PRODUCTS"."MEASURES" cascade constraints;
DROP TABLE "PRODUCTS"."PRODUCTS" cascade constraints;
DROP TABLE "PRODUCTS"."TOWNS" cascade constraints;
DROP TABLE "PRODUCTS"."VENDORS" cascade constraints;
DROP SEQUENCE "PRODUCTS"."MEASUREID_SEQ";
DROP SEQUENCE "PRODUCTS"."PRODUCTS_SEQ";
DROP SEQUENCE "PRODUCTS"."PRODUCTS_SEQ1";
DROP SEQUENCE "PRODUCTS"."TOWNS_SEQ";
DROP SEQUENCE "PRODUCTS"."VENDORID_SEQ";
--------------------------------------------------------
--  DDL for Sequence MEASUREID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRODUCTS"."MEASUREID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence PRODUCTS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRODUCTS"."PRODUCTS_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence PRODUCTS_SEQ1
--------------------------------------------------------

   CREATE SEQUENCE  "PRODUCTS"."PRODUCTS_SEQ1"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence TOWNS_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRODUCTS"."TOWNS_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence VENDORID_SEQ
--------------------------------------------------------

   CREATE SEQUENCE  "PRODUCTS"."VENDORID_SEQ"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table MEASURES
--------------------------------------------------------

  CREATE TABLE "PRODUCTS"."MEASURES" 
   (	"ID" NUMBER(*,0), 
	"MEASURENAME" NVARCHAR2(20), 
	"SHORT" NVARCHAR2(20)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table PRODUCTS
--------------------------------------------------------

  CREATE TABLE "PRODUCTS"."PRODUCTS" 
   (	"ID" NUMBER(*,0), 
	"VENDORID" NUMBER(*,0), 
	"MEASUREID" NUMBER(*,0), 
	"PRODUCTYPE" NVARCHAR2(200), 
	"PRODUCTNAME" NVARCHAR2(200), 
	"PRICE" NUMBER(10,2), 
	"QUANTITY" NUMBER(3,3), 
	"DISTRIBUTORID" NUMBER(*,0), 
	"PROMOID" NUMBER(*,0), 
	"TOWN" NVARCHAR2(200), 
	"PRODUCTIONDATE" DATE, 
	"EXPIRYDATE" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table TOWNS
--------------------------------------------------------

  CREATE TABLE "PRODUCTS"."TOWNS" 
   (	"ID" NUMBER(*,0), 
	"NAME" NVARCHAR2(200)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table VENDORS
--------------------------------------------------------

  CREATE TABLE "PRODUCTS"."VENDORS" 
   (	"ID" NUMBER(*,0), 
	"VENDORNAME" NVARCHAR2(200), 
	"TOWNID" NUMBER(*,0), 
	"ADDRESS" NVARCHAR2(200), 
	"CONTACT" NVARCHAR2(200), 
	"MAINDISTRIBUTORID" NUMBER(*,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
REM INSERTING into PRODUCTS.MEASURES
SET DEFINE OFF;
Insert into PRODUCTS.MEASURES (ID,MEASURENAME,SHORT) values (1,'????????','kg.');
Insert into PRODUCTS.MEASURES (ID,MEASURENAME,SHORT) values (2,'?????','l.');
Insert into PRODUCTS.MEASURES (ID,MEASURENAME,SHORT) values (3,'?????','pkg.');
Insert into PRODUCTS.MEASURES (ID,MEASURENAME,SHORT) values (4,'?????','m.');
Insert into PRODUCTS.MEASURES (ID,MEASURENAME,SHORT) values (5,'??. ?????','sq. m.');
Insert into PRODUCTS.MEASURES (ID,MEASURENAME,SHORT) values (6,'????','g.');
Insert into PRODUCTS.MEASURES (ID,MEASURENAME,SHORT) values (7,'?????????','ml.');
Insert into PRODUCTS.MEASURES (ID,MEASURENAME,SHORT) values (8,'????','??.');
REM INSERTING into PRODUCTS.PRODUCTS
SET DEFINE OFF;
Insert into PRODUCTS.PRODUCTS (ID,VENDORID,MEASUREID,PRODUCTYPE,PRODUCTNAME,PRICE,QUANTITY,DISTRIBUTORID,PROMOID,TOWN,PRODUCTIONDATE,EXPIRYDATE) values (1,1,1,'Beer','Zagorka ????? 0,5 l',1.1,0.5,null,null,null,null,null);
Insert into PRODUCTS.PRODUCTS (ID,VENDORID,MEASUREID,PRODUCTYPE,PRODUCTNAME,PRICE,QUANTITY,DISTRIBUTORID,PROMOID,TOWN,PRODUCTIONDATE,EXPIRYDATE) values (2,4,3,'????????','?????? 680 ??.',2.11,0.68,null,null,null,null,null);
Insert into PRODUCTS.PRODUCTS (ID,VENDORID,MEASUREID,PRODUCTYPE,PRODUCTNAME,PRICE,QUANTITY,DISTRIBUTORID,PROMOID,TOWN,PRODUCTIONDATE,EXPIRYDATE) values (3,3,3,'????????','??????? 290 ??.',1.89,null,null,null,null,null,null);
REM INSERTING into PRODUCTS.TOWNS
SET DEFINE OFF;
Insert into PRODUCTS.TOWNS (ID,NAME) values (1,'Sofia');
Insert into PRODUCTS.TOWNS (ID,NAME) values (2,'Varna');
Insert into PRODUCTS.TOWNS (ID,NAME) values (3,'Plovdiv');
Insert into PRODUCTS.TOWNS (ID,NAME) values (4,'Rousse');
Insert into PRODUCTS.TOWNS (ID,NAME) values (5,'Burgas');
Insert into PRODUCTS.TOWNS (ID,NAME) values (6,'Veliko Tarnovo');
Insert into PRODUCTS.TOWNS (ID,NAME) values (7,'Stara Zagora');
Insert into PRODUCTS.TOWNS (ID,NAME) values (8,'Nova Zagora');
Insert into PRODUCTS.TOWNS (ID,NAME) values (9,'Vidin');
Insert into PRODUCTS.TOWNS (ID,NAME) values (10,'Blagoevgrad');
Insert into PRODUCTS.TOWNS (ID,NAME) values (11,'Vratza');
Insert into PRODUCTS.TOWNS (ID,NAME) values (12,'Pleven');
Insert into PRODUCTS.TOWNS (ID,NAME) values (13,'Shumen');
Insert into PRODUCTS.TOWNS (ID,NAME) values (14,'Mezdra');
Insert into PRODUCTS.TOWNS (ID,NAME) values (15,'Haskovo');
Insert into PRODUCTS.TOWNS (ID,NAME) values (16,'Lom');
Insert into PRODUCTS.TOWNS (ID,NAME) values (17,'Gabrovo');
Insert into PRODUCTS.TOWNS (ID,NAME) values (18,'Silistra');
Insert into PRODUCTS.TOWNS (ID,NAME) values (19,'Karlovo');
Insert into PRODUCTS.TOWNS (ID,NAME) values (20,'Kazanlak');
REM INSERTING into PRODUCTS.VENDORS
SET DEFINE OFF;
Insert into PRODUCTS.VENDORS (ID,VENDORNAME,TOWNID,ADDRESS,CONTACT,MAINDISTRIBUTORID) values (1,'Zagorka Company',7,'Stara Zagora',null,null);
Insert into PRODUCTS.VENDORS (ID,VENDORNAME,TOWNID,ADDRESS,CONTACT,MAINDISTRIBUTORID) values (2,'�???????? ? ??" ?? ',14,'Mezdra',null,null);
Insert into PRODUCTS.VENDORS (ID,VENDORNAME,TOWNID,ADDRESS,CONTACT,MAINDISTRIBUTORID) values (3,'Pobeda AD',5,'??. �?????� 15',null,null);
Insert into PRODUCTS.VENDORS (ID,VENDORNAME,TOWNID,ADDRESS,CONTACT,MAINDISTRIBUTORID) values (4,'"Drujba" Cannery',2,null,null,null);
--------------------------------------------------------
--  DDL for Index MEASUREID_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRODUCTS"."MEASUREID_PK" ON "PRODUCTS"."MEASURES" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PRODUCTS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRODUCTS"."PRODUCTS_PK" ON "PRODUCTS"."PRODUCTS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index TOWNS_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRODUCTS"."TOWNS_PK" ON "PRODUCTS"."TOWNS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index VENDORID_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "PRODUCTS"."VENDORID_PK" ON "PRODUCTS"."VENDORS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table MEASURES
--------------------------------------------------------

  ALTER TABLE "PRODUCTS"."MEASURES" ADD CONSTRAINT "MEASUREID_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "PRODUCTS"."MEASURES" MODIFY ("MEASURENAME" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS"."MEASURES" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table PRODUCTS
--------------------------------------------------------

  ALTER TABLE "PRODUCTS"."PRODUCTS" ADD CONSTRAINT "PRODUCTS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "PRODUCTS"."PRODUCTS" MODIFY ("PRICE" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS"."PRODUCTS" MODIFY ("PRODUCTYPE" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS"."PRODUCTS" MODIFY ("MEASUREID" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS"."PRODUCTS" MODIFY ("VENDORID" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS"."PRODUCTS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table TOWNS
--------------------------------------------------------

  ALTER TABLE "PRODUCTS"."TOWNS" ADD CONSTRAINT "TOWNS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "PRODUCTS"."TOWNS" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS"."TOWNS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table VENDORS
--------------------------------------------------------

  ALTER TABLE "PRODUCTS"."VENDORS" ADD CONSTRAINT "VENDORID_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "PRODUCTS"."VENDORS" MODIFY ("VENDORNAME" NOT NULL ENABLE);
  ALTER TABLE "PRODUCTS"."VENDORS" MODIFY ("ID" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Trigger MEASUREID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PRODUCTS"."MEASUREID_TRG" 
BEFORE INSERT ON MEASURES 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT MEASUREID_SEQ.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "PRODUCTS"."MEASUREID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger PRODUCTS_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PRODUCTS"."PRODUCTS_TRG" 
BEFORE INSERT ON PRODUCTS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT PRODUCTS_SEQ1.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "PRODUCTS"."PRODUCTS_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TOWNS_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PRODUCTS"."TOWNS_TRG" 
BEFORE INSERT ON TOWNS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT TOWNS_SEQ.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "PRODUCTS"."TOWNS_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger VENDORID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "PRODUCTS"."VENDORID_TRG" 
BEFORE INSERT ON VENDORS 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF INSERTING AND :NEW.ID IS NULL THEN
      SELECT VENDORID_SEQ.NEXTVAL INTO :NEW.ID FROM SYS.DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;
/
ALTER TRIGGER "PRODUCTS"."VENDORID_TRG" ENABLE;
