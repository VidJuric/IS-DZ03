import React, { useState } from "react";
import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";

import { Employee, Osoba } from "../../services/types";
import Row from "./row";
import AddEditEmpolyee from "../addEditEmployee";
import axios from "axios";

interface Props {
    employees: Employee[];
    refreshEmployees(employee: Employee[]): void;
}

const MasterDetail: React.FC<Props> = ({ employees, refreshEmployees }) => {
    const [openEmployeeDialog, setOpenEmployeeDialog] = useState<boolean>(false);
    const [selectedEmployee, setSelectedEmployee] = useState<Osoba | null>(null);

    const handleEmployeeDialogOpen = (employee: Osoba | null) => {
        setOpenEmployeeDialog(true);
        setSelectedEmployee(employee);
    };

    const handleEmployeeDialogClose = (refresh: boolean) => {
        if (refresh) {
            axios.get<Employee[]>('https://localhost:44312/api/Osoba').then(res => {
                refreshEmployees(res.data)
            })
        }
        setOpenEmployeeDialog(false);
    };

    const refreshEmployee = (employees: Employee[]) => {
        refreshEmployees(employees)
    }

    return <TableContainer component={Paper}>
        <Typography variant="h5">
            Zaposlenici
        </Typography>
        <Button variant="outlined" size="small" onClick={() => handleEmployeeDialogOpen(null)}>
            Dodaj novog zaposlenika
        </Button>
        <Table aria-label="collapsible table">
            <TableHead>
                <TableRow>
                    <TableCell />
                    <TableCell align="center">OIB</TableCell>
                    <TableCell align="center">Ime</TableCell>
                    <TableCell align="center">Prezime</TableCell>
                    <TableCell align="center">Spol</TableCell>
                    <TableCell align="center">Email</TableCell>
                    <TableCell align="center">Akcije</TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {employees.map((row: Employee, index) => (
                    <Row key={index} employee={row} refreshEmployee={refreshEmployee} />
                ))}
            </TableBody>
        </Table>
        <AddEditEmpolyee
            open={openEmployeeDialog}
            onClose={handleEmployeeDialogClose}
            employee={null}
        />
    </TableContainer>
}

export default MasterDetail;