import numpy
import pandas
import matplotlib
import psycopg2
import os


# find path to CSV
file_path = os.path.join(os.getcwd(), "Sources.csv")
df = pandas.read_excel(file_path)

# retrieve database password (environment variable will be different for different users)
db_password = os.getenv('TG_DB_CONN2')

# connect using the retrieved database password
conn = psycopg2.connect(f"host=localhost dbname=NewsArticles user=postgres password= {db_password}")
cursor = conn.cursor()

# insert CSV data into the database as a record
for _, row in df.iterrows():
   cursor.execute("""
       INSERT INTO dbo."Sources" (
           "SourceId", "Name", "Bias", "Website"
       )
       VALUES (%s, %s, %s, %s);
   """, (
       row['SourceId'].strip(),
       row['Name'].strip(),
       row['Bias'].strip(),
       row['Website'].strip()
   ))


conn.commit()





