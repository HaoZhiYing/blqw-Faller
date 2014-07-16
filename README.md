����һ���������ı��ʽ���������  

��ʱֻ�����Where��Oracle����  
����û�в���  
����û��ע��  
�������ư�


####������ɫ  
* ���԰�DateTime.Nowת�������ݿ⵱ǰʱ�����,��Oracle��SYSDATE
```csharp
  Where(u => u.Birthday < DateTime.Now);    // a.BIRTHDAY < SYSDATE
```
* ������������C#���� -> ���ݿ⺯��,��
```csharp
  Where(u => u.Birthday.Day == 1);          //EXTRACT(DAY FROM a.BIRTHDAY) = 1
  Where(u => u.Name.Trim() == "");          //ltrim(rtrim(a.NAME)) = :auto_p0
  Where(u => string.IsNullOrEmpty(u.Name)); //a.NAME IS NULL OR a.NAME == ''
```
* �����ڱ��ʽ����������sql���ʽ
```csharp
  Where(u => (SqlExpr)"rownum < 10");               //rownum < 10
  Where(u => (SqlExpr)"rownum < 10" && u.ID > 10);  //rownum < 10 AND a.ID > 10
```