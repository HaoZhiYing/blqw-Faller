## ���  
Faller(������)��һ���������ı��ʽ���������  
��Ƴ����Ǿ����ļ򵥺����  
������Ҫ�κ����������֧��  
���Կ�������Ƕ�뵽�κ�����Ŀ��������Ŀ��  
��ͬ���ݿ����Ҫ����ʵ��[ISaw](https://code.csdn.net/jy02305022/blqw-faller/tree/master/blqw.Faller/interface/ISaw.cs)�ӿ�,���ɹ��첻ͬ��SQL���  
��ǰ�汾�ṩMsSql��Oracle�Ľ��ͷ�ʽ  
[MsSqlSaw](https://code.csdn.net/jy02305022/blqw-faller/tree/master/blqw.Faller/implement/MsSqlSaw.cs)  
[OracleSaw](https://code.csdn.net/jy02305022/blqw-faller/tree/master/blqw.Faller/implement/OracleSaw.cs)  
  
## ����˵��  
2014.07.22
�������
����ע��
�����˽���mssql�ķ�ʽ
2014.07.18
����2������
string ToValues(ISaw saw);
KeyValuePair<string, string> ToColumnsAndValues(ISaw saw);
2014.07.17
��ɲ��ִ���������ע�͹���
2014.07.16  
��Ԫ�����Ѿ������  
������Ҫ�������,�����ע��  
�������Ͱ�  


## ��ɫ  
#### ���԰�DateTime.Nowת�������ݿ⵱ǰʱ�����,��Oracle��SYSDATE  

    Where(u => u.Birthday < DateTime.Now);    // a.BIRTHDAY < SYSDATE  

#### ������������C#���� -> ���ݿ⺯��,��  

    Where(u => u.Birthday.Day == 1);          //EXTRACT(DAY FROM a.BIRTHDAY) = 1  
    Where(u => u.Name.Trim() == "");          //ltrim(rtrim(a.NAME)) = :auto_p0  
    Where(u => string.IsNullOrEmpty(u.Name)); //a.NAME IS NULL OR a.NAME == ''  

#### �����ڱ��ʽ����������sql���ʽ  

    Where(u => (SqlExpr)"rownum < 10");               //rownum < 10   
    Where(u => (SqlExpr)"rownum < 10" && u.ID > 10);  //rownum < 10 AND a.ID > 10  
