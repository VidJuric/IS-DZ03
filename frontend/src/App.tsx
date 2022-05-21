import axios from 'axios';
import { useEffect, useState } from 'react';
import './App.css';
import MasterDetail from './components/master-detail';
import { Osoba } from './services/types';

const App = () => {
  const [employees, setEmployees] = useState<Osoba[]>([]);

  useEffect(() => {
    axios.get<Osoba[]>('https://localhost:44312/api/Osoba').then(res => setEmployees(res.data))
  }, [])

  return (
    <div className="App">
      <MasterDetail employees={employees} />
    </div>
  );
}

export default App;
