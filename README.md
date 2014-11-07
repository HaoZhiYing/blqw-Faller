# blqw.Faller �������ı��ʽ���������,��!���!ǿ��!
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
#### 2014.11.07
* ����һ��lambda�г���2��Not()�������������� ��л����@������

#### 2014.11.05
* ֱ������LiteracyԴ��,�����ڶ���������Ŀ
* ��л���� @������ �ṩbug����
* ���ʵ�����пɿ�ֵ����.ToString() ���������
* ���ʵ�����пɿ�ֵ����.Value ���Ա��������
* ����֧��ʵ����ɿ�ֵ����.HasValue ���ԵĽ���,���ڿ��Եõ� xxx IS NULL ��sql���

#### 2014.10.21
* �������Сbug
* �Ż�����
* ����[Literacy](https://code.csdn.net/jy02305022/blqw.Literacy)�Ż�����

#### 2014.10.10
* �Ż�ToColumnsAndValues,Ҳ֧����������

#### 2014.09.17
* �������ʽ�� "".Split(char) �������ͱ��������  
* С�����Ż�
* ����һ��ʵ��Ӧ���е� Demo

#### 2014.07.23  
* �����˶��쳣�Ĵ���
* ������ʼ��Array������ɵĴ���
* �Ż���ʼ��Array�Ĳ���
* ȷ����֧�ֳ�ʼ��List���ʽ, ��`Where<User>(u => new List<int>() {1,2,3,4,5 }.Contains(u.ID));`������֧��,����ʹ��`Where<User>(u => new []{1,2,3,4,5 }.Contains(u.ID));`����  
* �Ż����ʽ�����ֻ��һ������ʵ�����,��sql�в�ʹ�ñ���
* ����SawDust���͵�ֵǶ�׿��ܴ���������

#### 2014.07.22  
* �������  
* ����ע��  
* �����˽���mssql�ķ�ʽ  
* ��֪BUG : �ڱ��ʼʽ�г�ʼ��List����Array�п����޷�����,���ڽ��

#### 2014.07.18  
* ���Ӳ��ַ���  

#### 2014.07.17  
* ��ɲ��ִ���������ע�͹���  

#### 2014.07.16  
* ��Ԫ�����Ѿ������  
* ������Ҫ�������,�����ע��  
* �������Ͱ�  


## ��ɫ  
#### ���԰�DateTime.Nowת�������ݿ⵱ǰʱ�����,��Oracle��SYSDATE  

    Where(u => u.Birthday < DateTime.Now);    // a.BIRTHDAY < SYSDATE  

#### ������������C#���� -> ���ݿ⺯��,��  

    Where(u => u.Birthday.Day == 1);          //EXTRACT(DAY FROM a.BIRTHDAY) = 1  
    Where(u => u.Name.Trim() == "");          //ltrim(rtrim(a.NAME)) = :auto_p0  
    Where(u => string.IsNullOrEmpty(u.Name)); //a.NAME IS NULL OR a.NAME = ''  

#### �����ڱ��ʽ����������sql���ʽ  

    Where(u => (SqlExpr)"rownum < 10");               //rownum < 10   
    Where(u => (SqlExpr)"rownum < 10" && u.ID > 10);  //rownum < 10 AND a.ID > 10  


##Demo����  
```csharp
public static class UserBLL
{
    public static List<User> GetUsers(Expression<Func<User, bool>> where)
    {
        var parse = Faller.Create(where);
        var sql = parse.ToWhere(new MySaw());
        using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Test;Integrated Security=True"))
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select * from test where " + sql;
            cmd.Parameters.AddRange(parse.Parameters.ToArray());
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                return Convert2.ToList<User>(reader);
            }
        }
    }
}
```