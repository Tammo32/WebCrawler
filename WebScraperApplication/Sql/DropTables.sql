if exists (select * from Information_Schema.Tables where Table_Name = 'Jobs')
begin
    drop table [Jobs];
end