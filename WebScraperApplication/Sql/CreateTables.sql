if not exists (select * from Information_Schema.Tables where Table_Name = 'Jobs')
begin
    create table Jobs
    (
        JobID varchar(36) not null,
        Title nvarchar(255) not null,
        Company nvarchar(255) null,
        [Description] text null,
        [Availability] varchar(10) null,
        [Url] text not null,
        Salary varchar(7) null,
        constraint PK_Job primary key (JobID),
    );
end

if not exists (select * from Information_Schema.Tables where Table_Name = 'JobSearchResults')
begin
    create table JobSearchResults
    (
        ID varchar(36) not null,
        UserID nvarchar(450) not null,
        ResultsDate datetime not null,
        constraint PK_JobSearchResults primary key (ID),
        constraint FK_JobsSearchResults_User foreign key (UserID) references AspNetUsers (id)
    );
end

if not exists (select * from Information_Schema.Tables where Table_Name = 'Jobs_JobSearchResults_Bridge')
begin
    create table Jobs_JobSearchResults_Bridge
    (
        ID varchar(36) not null,
        JobID varchar(36) not null,
        UserID nvarchar(450) not null,
        constraint PK_Jobs_JobSearchResults_Bridge primary key (ID),
        constraint FK_Jobs_JobSearchResults_Jobs foreign key (JobID) references Jobs (JobID),
        constraint FK_Jobs_JobSearchResults_AspNetUser foreign key (UserID) references AspNetUsers (id)
    );
end

if not exists (select * from Information_Schema.Tables where Table_Name = 'UserPreferences')
begin
    create table UserPreferences
    (
        ID varchar(36) not null,
        UserID nvarchar(450) not null,
        EmailFrequency int not null,
        EmailDay int not null,
        constraint PK_UserPreferences primary key (ID),
        constraint FK_UserPreferences_AspNetUser foreign key (UserID) references AspNetUsers (id)
    );
end

if not exists (select * from Information_Schema.Tables where Table_Name = 'UserJobSearchQueries')
begin
    create table UserJobSearchQueries
    (
        ID varchar(36) not null,
        UserID nvarchar(450) not null,
        QueryUrl nvarchar(255) not null,
        constraint PK_UserJobSearchQueries primary key (ID),
        constraint FK_UserJobSearchQueries_AspNetUser foreign key (UserID) references AspNetUsers (id)
    );
end