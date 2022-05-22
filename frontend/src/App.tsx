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

  return (
    <div className="App">
      <MasterDetail employees={employees.slice(0, 10)} />
    </div>
  );
}

export default App;
