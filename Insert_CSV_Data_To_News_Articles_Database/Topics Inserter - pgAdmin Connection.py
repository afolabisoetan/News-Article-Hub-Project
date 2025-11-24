import numpy
import pandas
import matplotlib
import psycopg2
import os


# find path to CSV
file_path = os.path.join(os.getcwd(), "Topics.csv")
df = pandas.read_excel(file_path)

# retrieve database password (environment variable will be different for different users)
db_password = os.getenv('TG_DB_CONN3')

# connect using the retrieved database password
conn = psycopg2.connect(f"host=localhost dbname=NewsArticles user=postgres password={db_password}")
cursor = conn.cursor()

# insert CSV data into the database as a record
for _, row in df.iterrows():
   cursor.execute("""
       INSERT INTO dbo."Topics" (
           "TopicId", "Name", "Description"
       )
       VALUES (%s, %s, %s);
   """, (
       row['TopicId'].strip(),
       row['Name'].strip(),
       row['Description'].strip(),
   ))


conn.commit()





