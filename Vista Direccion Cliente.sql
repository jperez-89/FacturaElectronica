/****** Script para el comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) [id]
      ,[typeDNI]
      ,[DNI]
      ,[name]
      ,[districtID]
      ,[email]
      ,[phone]
      ,[state]
  FROM [Market].[SC_ADMIN].[Client]


  select pro.name AS PROVINCIA, can.name AS CANTON, dis.name AS DISTRITO, cli.name AS NOMBRECLIENTE from SC_ADMIN.Province as pro
  inner join SC_ADMIN.Canton as can on can.provinceID = pro.id
  inner join SC_ADMIN.District as dis on dis.cantonID = can.id
  inner join SC_ADMIN.Client as cli on cli.districtID = dis.id
  

