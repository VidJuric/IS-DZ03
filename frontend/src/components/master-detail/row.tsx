import React, { useEffect, useState } from "react";
import { TableRow, TableCell, IconButton, Collapse, Box, Typography, Table, TableBody, TableHead, Button } from "@mui/material";
import PropTypes from 'prop-types';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { CustomerSupport, DeleteInformation, DropdownValues, Employee, Osoba, StatusZadatka, Usluga, Zadatak, ZadatakExtended } from "../../services/types";
import axios from "axios";
import { get, find } from 'lodash'
import AddEditTask from "../addEditTask";
import ConfirmationDialog from "../confirmationDialog";
import AddEditEmpolyee from "../addEditEmployee";

interface Props {
    employee: Employee;
    refreshEmployee(employee: Employee[]): void;
}

const Row: React.FC<Props> = ({ employee, refreshEmployee }) => {
    const [open, setOpen] = useState(false)
    const [tasks, setTasks] = useState<ZadatakExtended[]>([])
    const [taskStatus, setTaskStatus] = useState<StatusZadatka[]>([])
    const [services, setServices] = useState<Usluga[]>([])
    const [customerSupport, setCustomerSupport] = useState<CustomerSupport[]>([])

    const [taskDialogOpen, setTaskDialogOpen] = useState(false)
    const [selectedTask, setSelectedTask] = useState<Zadatak | null>(null)

    const [selectedEmployee, setSelectedEmployee] = useState<Osoba | null>(null);
    const [openEmployeeDialog, setOpenEmployeeDialog] = useState<boolean>(false);

    const [deleteDialog, setDeleteDialog] = useState<boolean>(false)
    const [deleteInformation, setDeleteInformation] = useState<DeleteInformation>({ id: 0, name: '' })

    const [deleteEmployeeDialog, setDeleteEmployeeDialog] = useState<boolean>(false)
    const [deleteEmployeeInformation, setDeleteEmployeeInformation] = useState<DeleteInformation>({ id: 0, name: '' })


    const handleTaskDialogOpen = (task: Zadatak | null) => {
        setTaskDialogOpen(true);
        setSelectedTask(task);
    };

    const handleTaskDialogClose = (refresh: boolean) => {
        if (refresh) {
            axios.get<Zadatak[]>(`https://localhost:44312/api/Zadatak/${employee.zaposlenikID}`).then(res => {
                const mappedTasks: ZadatakExtended[] = res.data.map(row => {
                    return {
                        ...row,
                        statusZadatka: get(find(taskStatus, { statusZadatkaID: row.statusZadatkaID }), 'opisStatusa', 'Nepoznato'),
                        usluga: get(find(services, { uslugaID: row.uslugaID }), 'opisUsluga', 'Nepoznato'),
                    }
                })
                setTasks(mappedTasks);
            })
        }
        setTaskDialogOpen(false);
    };

    const handleEmployeeDialogOpen = (employee: Osoba | null) => {
        setOpenEmployeeDialog(true);
        setSelectedEmployee(employee);
    };

    const handleEmployeeDialogClose = (refresh: boolean) => {
        if (refresh) {
            axios.get<Employee[]>('https://localhost:44312/api/Osoba').then(res => refreshEmployee(res.data))
        }
        setOpenEmployeeDialog(false);
    };

    const handleDeleteEmployeeOpen = (oib: string, employeeName: string) => {
        setDeleteEmployeeInformation({ id: -1, oib: oib, name: employeeName })
        setDeleteEmployeeDialog(open)
    }

    const handleDeleteEmployeeClose = () => {
        setDeleteEmployeeDialog(false)
    }

    const handleDeleteTaskOpen = (taskID: number, taskName: string) => {
        setDeleteInformation({ id: taskID, name: taskName })
        setDeleteDialog(open)
    }

    const handleDeleteTaskClose = () => {
        setDeleteDialog(false)
    }

    const deleteTask = (taskID: number) => {
        axios.delete(`https://localhost:44312/api/Zadatak/${taskID}`).then(() => {
            axios.get<Zadatak[]>(`https://localhost:44312/api/Zadatak/${employee.zaposlenikID}`).then(res => {
                const mappedTasks: ZadatakExtended[] = res.data.map(row => {
                    return {
                        ...row,
                        statusZadatka: get(find(taskStatus, { statusZadatkaID: row.statusZadatkaID }), 'opisStatusa', 'Nepoznato'),
                        usluga: get(find(services, { uslugaID: row.uslugaID }), 'opisUsluga', 'Nepoznato'),
                    }
                })
                setTasks(mappedTasks);
            })
        })
    }

    const deleteEmployee = (oib: string) => {
        axios.delete(`https://localhost:44312/api/Osoba/${oib}`).then(() => {
            axios.get<Employee[]>('https://localhost:44312/api/Osoba').then(res => console.log(res.data))
        })
    }

    useEffect(() => {
        Promise.all([axios.get<Zadatak[]>(`https://localhost:44312/api/Zadatak/${employee.zaposlenikID}`),
        axios.get<StatusZadatka[]>('https://localhost:44312/api/StatusZadatka'),
        axios.get<Usluga[]>('https://localhost:44312/api/Usluga'),
        axios.get<CustomerSupport[]>('https://localhost:44312/api/Osoba/CustomerSupport')])
            .then(([{ data: taskData }, { data: taskStatusData }, { data: serviceData }, { data: customerSupportData }]) => {
                const mappedTasks: ZadatakExtended[] = taskData.map(row => {
                    return {
                        ...row,
                        statusZadatka: get(find(taskStatusData, { statusZadatkaID: row.statusZadatkaID }), 'opisStatusa', 'Nepoznato'),
                        usluga: get(find(serviceData, { uslugaID: row.uslugaID }), 'opisUsluga', 'Nepoznato'),
                    }
                })
                setTasks(mappedTasks);
                setTaskStatus(taskStatusData);
                setServices(serviceData);
                setCustomerSupport(customerSupportData);
            })
    }, [employee.zaposlenikID])

    return <React.Fragment>
        <TableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
            <TableCell>
                <IconButton
                    aria-label="expand row"
                    size="small"
                    onClick={() => setOpen(!open)}
                >
                    {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
                </IconButton>
            </TableCell>
            <TableCell align="center">{employee.oib}</TableCell>
            <TableCell align="center">{employee.ime}</TableCell>
            <TableCell align="center">{employee.prezime}</TableCell>
            <TableCell align="center">{employee.spol}</TableCell>
            <TableCell align="center">{employee.email}</TableCell>
            <TableCell align="center">
                <>
                    <IconButton aria-label="edit" onClick={() => handleEmployeeDialogOpen(employee)}>
                        <EditIcon />
                    </IconButton>
                    <IconButton aria-label="delete" onClick={() => handleDeleteEmployeeOpen(employee.oib, `${employee.ime} ${employee.prezime}`)}>
                        <DeleteIcon />
                    </IconButton>
                </>
            </TableCell>
        </TableRow>
        <TableRow>
            <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={7}>
                <Collapse in={open} timeout="auto" unmountOnExit>
                    <Box sx={{ margin: 1 }}>
                        <Typography variant="h5">
                            Zadaci
                        </Typography>
                        <Button variant="outlined" size="small" onClick={() => handleTaskDialogOpen(null)}>
                            Dodaj novi zadatak
                        </Button>
                        <Table size="small" aria-label="purchases">
                            <TableHead>
                                <TableRow>
                                    <TableCell align="center">Opis</TableCell>
                                    <TableCell align="center">Korisnicka Sluzba</TableCell>
                                    <TableCell align="center">Status Zadatka</TableCell>
                                    <TableCell align="center">Usluga</TableCell>
                                    <TableCell align="center">Actions</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {tasks.map((task) => (
                                    <>
                                        <TableRow key={task.zadatakID}>
                                            <TableCell align="center">{task.opis}</TableCell>
                                            <TableCell align="center">{task.korisnickaSluzbaImePrezime}</TableCell>
                                            <TableCell align="center">{task.statusZadatka}</TableCell>
                                            <TableCell align="center">{task.usluga}</TableCell>
                                            <TableCell align="center">
                                                <>
                                                    <IconButton aria-label="edit" onClick={() => handleTaskDialogOpen(task)}>
                                                        <EditIcon />
                                                    </IconButton>
                                                    <IconButton aria-label="delete" onClick={() => handleDeleteTaskOpen(task.zadatakID, '')}>
                                                        <DeleteIcon />
                                                    </IconButton>
                                                </>
                                            </TableCell>
                                        </TableRow>
                                        <ConfirmationDialog
                                            open={deleteDialog}
                                            name={deleteInformation.name}
                                            deleteSelected={() => deleteTask(deleteInformation.id)}
                                            onClose={handleDeleteTaskClose}
                                        />
                                    </>
                                ))}
                            </TableBody>
                        </Table>
                    </Box>
                </Collapse>
            </TableCell>
        </TableRow>
        <AddEditEmpolyee
            open={openEmployeeDialog}
            onClose={handleEmployeeDialogClose}
            employee={selectedEmployee}
        />
        <ConfirmationDialog
            open={deleteEmployeeDialog}
            name={deleteEmployeeInformation.name}
            deleteSelected={() => deleteEmployee(deleteEmployeeInformation.oib ? deleteEmployeeInformation.oib : '')}
            onClose={handleDeleteEmployeeClose}
        />
        <AddEditTask
            open={taskDialogOpen}
            onClose={handleTaskDialogClose}
            task={selectedTask}
            zaposlenikID={employee.zaposlenikID}
            taskStatus={taskStatus.map<DropdownValues>(({ statusZadatkaID, opisStatusa }) => ({ id: statusZadatkaID, value: opisStatusa }))}
            services={services.map<DropdownValues>(({ uslugaID, opisUsluga }) => ({ id: uslugaID, value: opisUsluga }))}
            customerSupport={customerSupport.map<DropdownValues>(({ korisnickaSluzbaID, ime, prezime }) => ({ id: korisnickaSluzbaID, value: `${ime} ${prezime}` }))}
        />
    </React.Fragment>
}

Row.propTypes = {
    employee: PropTypes.shape({
        oib: PropTypes.string.isRequired,
        ime: PropTypes.string.isRequired,
        prezime: PropTypes.string.isRequired,
        datumRodjenja: PropTypes.instanceOf(Date).isRequired,
        spol: PropTypes.string.isRequired,
        datumZaposlenja: PropTypes.instanceOf(Date).isRequired,
        email: PropTypes.string.isRequired,
        zaposlenikID: PropTypes.number.isRequired,
    }).isRequired,
};

export default Row;