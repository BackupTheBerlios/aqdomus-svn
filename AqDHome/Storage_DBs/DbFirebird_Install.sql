/*
 * DbFirebird_Install.sql
 *
 * Copyright (c) 2004 Aquila Deus
 * Licensed under the Open Software License version 2.1
 */


-- Domain for IDs, usually auto-generated IDs and primary keys.
-------------------------------------------------------------------------------
create domain CTYPE_ID as int not null;
commit;

-- Domain for ID references.
-------------------------------------------------------------------------------
create domain CTYPE_ID_REF as int;
commit;

-- Domain for string-type keys, usually primary keys.
-------------------------------------------------------------------------------
create domain CTYPE_NAME as nchar varying(64) not null check (
  value != '' and value not like ' %'
);
commit;

-- Domain for string-type references, usually references to string-type keys.
-------------------------------------------------------------------------------
create domain CTYPE_NAME_REF as nchar varying(64);
commit;

-- Domain for integer counters.
-------------------------------------------------------------------------------
create domain CTYPE_COUNTER as int default 0 not null;
commit;

-- Domain for time fields.
-------------------------------------------------------------------------------
create domain CTYPE_TIME as timestamp not null;
commit;

-- Domain for short/single-line text.
-------------------------------------------------------------------------------
create domain CTYPE_LINE as nchar varying(512) default '' not null;
commit;

-- Domain for long text.
-------------------------------------------------------------------------------
create domain CTYPE_TEXT as nchar varying(4096) default '' not null;
commit;


-------------------------------------------------------------------------------
-- [ ATOM_INSTANCE ] ----------------------------------------------------------
--
-- An ATOM_INSTANCE should always be created together with some other
-- XXX_HANDLE(s), and the ATOM_ON_REMOVE_LINK must be called whenever a
-- XXX_HANDLE is assigned.
--
-- After removing a XXX_HANDLE assigned to some ATOM_INSTANCE, the
-- ATOM_DECREASE_LINK must be called. An ATOM_INSTANCE would automatically
-- delete itself if there is no XXX_HANDLE assigned to it.
-------------------------------------------------------------------------------

-- Table for actual atom references.
-------------------------------------------------------------------------------
create table ATOM_INSTANCE (
  HANDLE_ID CTYPE_ID,
  INSTANCE_PROVIDER CTYPE_NAME,
  INSTANCE_ID CTYPE_NAME,
  CREATION_TIME CTYPE_TIME,
  UPDATE_TIME CTYPE_TIME,
  LINK_COUNT CTYPE_COUNTER,
  primary key (HANDLE_ID),
  unique (INSTANCE_PROVIDER, INSTANCE_ID),
  check (LINK_COUNT >= 0)
);
commit;

-- Generator for generating ATOM_INSTANCE.HANDLE_ID
-------------------------------------------------------------------------------
create generator ATOM_INSTANCE_ID_GEN;
commit;

-- Trigger to generate ATOM_INSTANCE.HANDLE_ID automatically
-------------------------------------------------------------------------------
set term !! ;
create trigger ATOM_INSTANCE_GEN_ID for ATOM_INSTANCE
before insert
as
begin
  if (new.HANDLE_ID is null) then
    new.HANDLE_ID = gen_id(ATOM_INSTANCE_ID_GEN, 1);
end !!
set term ; !!
commit;

-- Procedure to call when a link is created and assigned to this ATOM
-------------------------------------------------------------------------------
set term !! ;
create procedure ATOM_ON_ADD_LINK (HANDLE_ID int)
as
begin
  update ATOM_INSTANCE set LINK_COUNT = LINK_COUNT + 1
    where HANDLE_ID = :HANDLE_ID;
end !!
set term ; !!

-- Procedure to call when a link to this ATOM is removed
-------------------------------------------------------------------------------
set term !! ;
create procedure ATOM_ON_REMOVE_LINK (HANDLE_ID int)
as
  declare variable CUR_LCOUNT int;
begin
  select LINK_COUNT from ATOM_INSTANCE
  where HANDLE_ID = :HANDLE_ID
  into :CUR_LCOUNT;

  if (CUR_LCOUNT <= 1) then
    delete from ATOM_INSTANCE where HANDLE_ID = :HANDLE_ID;
  else
    update ATOM_INSTANCE set LINK_COUNT = LINK_COUNT - 1
    where HANDLE_ID = :HANDLE_ID;

end !!
set term ; !!


-------------------------------------------------------------------------------
-- [ DOCUMENT_HANDLE ] --------------------------------------------------------
-------------------------------------------------------------------------------

-- Table for (virtual) document folders
-------------------------------------------------------------------------------
create table DOCUMENT_FOLDER (
  FOLDER_ID CTYPE_ID,
  FOLDER_NAME CTYPE_NAME,
  PARENT_FOLDER_ID CTYPE_ID_REF,
  FOLDER_DESCRIPTION CTYPE_TEXT,
  primary key (FOLDER_ID),
  foreign key (FOLDER_ID) references DOCUMENT_FOLDER (FOLDER_ID),
  unique (FOLDER_NAME, PARENT_FOLDER_ID),
  check (FOLDER_NAME NOT LIKE '%/%')
);
commit;

-- Generator for generating DOCUMENT_FOLDER.FOLDER_ID
-------------------------------------------------------------------------------
create generator DOCUMENT_FOLDER_ID_GEN;
commit;

-- Trigger to generate DOCUMENT_FOLDER.FOLDER_ID automatically
-------------------------------------------------------------------------------
set term !! ;
create trigger DOCUMENT_FOLDER_GEN_ID for DOCUMENT_FOLDER
before insert
as
begin
  if (new.FOLDER_ID is null) then
    new.FOLDER_ID = gen_id(DOCUMENT_FOLDER_ID_GEN, 1);
end !!
set term ; !!
commit;

-- Table for document types
-------------------------------------------------------------------------------
create table DOCUMENT_TYPE (
  TYPE_NAME CTYPE_NAME,
  TYPE_DESCRIPTION CTYPE_TEXT,
  primary key (TYPE_NAME)
);
commit;

-- Table for document authors
-------------------------------------------------------------------------------
create table DOCUMENT_AUTHOR (
  AUTHOR_NAME CTYPE_NAME,
  AUTHOR_DESCRIPTION CTYPE_TEXT,
  primary key (AUTHOR_NAME)
);
commit;

-- Table for document-type atom references
-------------------------------------------------------------------------------
create table DOCUMENT_HANDLE (
  HANDLE_ID CTYPE_ID,
  FOLDER_ID CTYPE_ID_REF,
  DOCUMENT_NAME CTYPE_NAME,
  TYPE_NAME CTYPE_NAME,
  AUTHOR_NAME CTYPE_NAME,
  primary key (HANDLE_ID),
  foreign key (HANDLE_ID) references ATOM_INSTANCE,
  foreign key (FOLDER_ID) references DOCUMENT_FOLDER,
  foreign key (TYPE_NAME) references DOCUMENT_TYPE,
  foreign key (AUTHOR_NAME) references DOCUMENT_AUTHOR on update cascade
);
commit;

-- Trigger to call after insertion of a DOCUMENT_HANDLE
-------------------------------------------------------------------------------
set term !! ;
create trigger DOCUMENT_AFTER_INSERT for DOCUMENT_HANDLE
after insert
as
begin
  execute procedure ATOM_ON_ADD_LINK(new.HANDLE_ID);
end !!
set term ; !!
commit;

-- Trigger to call after removal of a DOCUMENT_HANDLE
-------------------------------------------------------------------------------
set term !! ;
create trigger DOCUMENT_AFTER_DELETE for DOCUMENT_HANDLE
after delete
as
begin
  execute procedure ATOM_ON_REMOVE_LINK(old.HANDLE_ID);
end !!
set term ; !!
commit;


-------------------------------------------------------------------------------
-- [ PICTURE_HANDLE ] ---------------------------------------------------------
-------------------------------------------------------------------------------

-- Table for picture types
-------------------------------------------------------------------------------
create table PICTURE_TYPE (
  TYPE_NAME CTYPE_NAME,
  TYPE_DESCRIPTION CTYPE_TEXT,
  primary key (TYPE_NAME)
);
commit;

-- Table for (virtual) picture authors
-------------------------------------------------------------------------------
create table PICTURE_AUTHOR (
  AUTHOR_NAME CTYPE_NAME,
  AUTHOR_DESCRIPTION CTYPE_TEXT,
  primary key (AUTHOR_NAME)
);
commit;

-- Table for picture-type atom references
-------------------------------------------------------------------------------
create table PICTURE_HANDLE (
  HANDLE_ID CTYPE_ID,
  PICTURE_NAME CTYPE_NAME,
  TYPE_NAME CTYPE_NAME,
  AUTHOR_NAME CTYPE_NAME_REF,
  PICTURE_COPYRIGHT CTYPE_LINE,
  PICTURE_DESCRIPTION CTYPE_TEXT,
  primary key (HANDLE_ID),
  foreign key (HANDLE_ID) references ATOM_INSTANCE,
  foreign key (TYPE_NAME) references PICTURE_TYPE on update cascade,
  foreign key (AUTHOR_NAME) references PICTURE_AUTHOR on update cascade
);
commit;

-- Trigger to call after insertion of a PICTURE_HANDLE
-------------------------------------------------------------------------------
set term !! ;
create trigger PICTURE_AFTER_INSERT for PICTURE_HANDLE
after insert
as
begin
  execute procedure ATOM_ON_ADD_LINK(new.HANDLE_ID);
end !!
set term ; !!
commit;

-- Trigger to call after removal of a PICTURE_HANDLE
-------------------------------------------------------------------------------
set term !! ;
create trigger PICTURE_AFTER_DELETE for PICTURE_HANDLE
after delete
as
begin
  execute procedure ATOM_ON_REMOVE_LINK(old.HANDLE_ID);
end !!
set term ; !!
commit;


-------------------------------------------------------------------------------
-- [ WEBLINK_HANDLE ] ---------------------------------------------------------
-------------------------------------------------------------------------------

-- Table for weblink-type atom references
-------------------------------------------------------------------------------
create table WEBLINK_HANDLE (
  HANDLE_ID CTYPE_ID,
  WEBLINK_NAME CTYPE_NAME,
  WEBLINK_DESCRIPTION CTYPE_TEXT,
  primary key (HANDLE_ID),
  foreign key (HANDLE_ID) references ATOM_INSTANCE
);
commit;

-- Trigger to call after insertion of a WEBLINK_HANDLE
-------------------------------------------------------------------------------
set term !! ;
create trigger WEBLINK_AFTER_INSERT for WEBLINK_HANDLE
after insert
as
begin
  execute procedure ATOM_ON_ADD_LINK(new.HANDLE_ID);
end !!
set term ; !!
commit;

-- Trigger to call after removal of a WEBLINK_HANDLE
-------------------------------------------------------------------------------
set term !! ;
create trigger WEBLINK_AFTER_DELETE for WEBLINK_HANDLE
after delete
as
begin
  execute procedure ATOM_ON_REMOVE_LINK(old.HANDLE_ID);
end !!
set term ; !!
commit;
