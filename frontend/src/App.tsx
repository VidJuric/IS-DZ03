import axios from 'axios';
import { useEffect, useState } from 'react';
import './App.css';
import MasterDetail from './components/master-detail';
import { Employee } from './services/types';

const App = () => {
  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    axios.get<Employee[]>('https://localhost:44312/api/Osoba').then(res => setEmployees(res.data))
  }, [])

  const refreshEmployees = (employees: Employee[]) => {
    setEmployees(employees);
  }

  return (
    <div className="App">
      <MasterDetail employees={employees.sort((e1, e2) => e1.zaposlenikID - e2.zaposlenikID).reverse()} refreshEmployees={refreshEmployees} />
    </div>
  );
}

export default App;
