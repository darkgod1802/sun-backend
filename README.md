
# Prueba técnica Mobile (Flutter)
Repositorio original: https://github.com/BsolTechnicalTest/BackEnd


#### 1.- Crea los servicios de CreateUpdateListGetByIdpara el los gastos (Expenses)


Análisis y solución: 
- Acorde a los endpoint de incomes se creo los enpoints requeridos para expenses, incluyendo su documentación

#### crea un End point para obtener el Balance por Rangos de fechas libre

Análisis y solución: 
- Se planteo hacerlo con query params modificando las consultas ya existente para fechas, pero no se logro terminarla

#### el DB admin nos ha dicho que estamos golpeando mucho la base de datos para obtener el Historial, y el mismo cliente consulta su historial 5 veces en  10 min , propon una mejora 

Análisis y solución: 
- Mi solución es implementar REDIS para el manejo de cache de 10 minutos de duración y en caso de detectar una nueva transacción se fuerce su limpieza

