## ���  
Faller(������)��һ���������ı��ʽ���������  
��Ƴ����Ǿ����ļ򵥺����  
������Ҫ�κ����������֧��  
���Կ�������Ƕ�뵽�κ�����Ŀ��������Ŀ��  
��ͬ���ݿ����Ҫ����ʵ��ISaw�ӿ�,���ɹ��첻ͬ��SQL���  


    public interface ISaw
    {
        string BinaryOperator(string left, BinaryOperatorType @operator, string right);
        string Contains(bool not, string element, string[] array);
    
        string AddObject(object obj, ICollection<DbParameter> parameters);
        string AddNumber(IConvertible number, ICollection<DbParameter> parameters);
        string AddBoolean(bool value, ICollection<DbParameter> parameters);
        string AddTimeNow(ICollection<DbParameter> parameters);
    
        string GetTable(Type type, string alias);
        string GetColumn(string table, MemberInfo member);
        string GetColumn(string columnName, string alias);
    
        string CallMethod(MethodInfo method, SawDust target, SawDust[] args);
    
        string OrderBy(string sql, bool asc);
    
        string UpdateSet(string column, string value);
    }


## ����˵��  
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
