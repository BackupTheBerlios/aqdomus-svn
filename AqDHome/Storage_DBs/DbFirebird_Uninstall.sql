/*
 * DbFirebird_Install.sql
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


drop trigger WEBLINK_AFTER_DELETE;
drop trigger WEBLINK_AFTER_INSERT;
drop table WEBLINK_HANDLE;

drop trigger PICTURE_AFTER_DELETE;
drop trigger PICTURE_AFTER_INSERT;
drop table PICTURE_HANDLE;
drop table PICTURE_AUTHOR;
drop table PICTURE_TYPE;

drop trigger DOCUMENT_AFTER_DELETE;
drop trigger DOCUMENT_AFTER_INSERT;
drop table DOCUMENT_HANDLE;
drop table DOCUMENT_AUTHOR;
drop table DOCUMENT_TYPE;
drop trigger DOCUMENT_FOLDER_GEN_ID;
drop generator DOCUMENT_FOLDER_ID_GEN;
drop table DOCUMENT_FOLDER;

drop procedure ATOM_ON_ADD_LINK;
drop procedure ATOM_ON_REMOVE_LINK;
drop trigger ATOM_INSTANCE_GEN_ID;
drop generator ATOM_INSTANCE_ID_GEN;
drop table ATOM_INSTANCE;

drop domain CTYPE_TEXT;
drop domain CTYPE_LINE;
drop domain CTYPE_TIME;
drop domain CTYPE_COUNTER;
drop domain CTYPE_NAME_REF;
drop domain CTYPE_NAME;
drop domain CTYPE_ID_REF;
drop domain CTYPE_ID;
