import numpy
import pandas
import matplotlib
import psycopg2
import os


# find path to CSV
file_path = os.path.join(os.getcwd(), "Articles.csv")
df = pandas.read_excel(file_path)

# retrieve database password (environment variable will be different for different users)
db_password = os.getenv('TG_DB_CONN2')

# connect using the retrieved database password
conn = psycopg2.connect(f"host=localhost dbname=NewsArticles user=postgres password={db_password}")
cursor = conn.cursor()

# insert CSV data into the database as a record
for _, row in df.iterrows():
   cursor.execute("""
       INSERT INTO dbo."Articles" (
           "ArticleId", "Title", "Url", "DateAdded", "TopicId", "SourceId","Description", "BiasValue"
       )
       VALUES (%s, %s, %s, %s, %s, %s, %s, %s);
   """, (
       row['ArticleId'].strip(),
       row['Title'].strip(),
       row['URL'].strip(),
       row['DateAdded'],
       row['TopicId'].strip(),
       row['SourceId'].strip(),
       row['Description'].strip(),
       row['Bias']
   ))

conn.commit()





