import React from "react";
import { useFormik } from "formik";
import * as yup from 'yup';
import { Osoba } from "../../services/types";
import { Dialog, Typography, DialogContent, Box, TextField, DialogActions, Button, FormControl, InputLabel, MenuItem, Select } from "@mui/material";
import axios from "axios";

interface Props {
    employee: Osoba | null;
    open: boolean;
    onClose: (value: boolean) => void;
}

const AddEditEmpolyee: React.FC<Props> = ({ employee, open, onClose }) => {
    const isAdd: boolean = employee ? false : true;

    const validationSchema = yup.object({
        oib: yup.string().length(11, 'OIB mora imati točno 11 znamenki').required('OIB je obavezno polje'),
        ime: yup.string().required('Ime je obavezno polje'),
        prezime: yup.string().required('Prezime je obavezno polje'),
        datumRodjenja: yup.date().required('Datum rođenja je obavezno polje'),
        spol: yup.string().required('Spol je obavezno polje'),
        datumZaposlenja: yup.date().required('Datum zaposlenja je obavezno polje'),
        email: yup.string().email('Email nije ispravan').required('Email je obavezno polje'),
    })

    const formik = useFormik({
        initialValues: {
            oib: employee ? employee.oib : '',
            ime: employee ? employee.ime : '',
            prezime: employee ? employee.prezime : '',
            datumRodjenja: employee ? employee.datumRodjenja : '',
            spol: employee ? employee.spol : 'M',
            datumZaposlenja: employee ? employee.datumZaposlenja : '',
            email: employee ? employee.email : '',
            lozinka: employee ? employee.lozinka : '',
        },
        validationSchema: validationSchema,
        onSubmit: values => {
            if (!isAdd && employee) {
                values.lozinka = ''
                axios.put<Osoba>(`https://localhost:44312/api/Osoba/${values.oib}`, values).then(() => {
                    handleClose(true)
                })
            } else {
                axios.post<Osoba>(`https://localhost:44312/api/Osoba`, values).then(() => {
                    handleClose(true)
                })
            }
        },
        enableReinitialize: true
    })

    const handleClose = (refresh: boolean) => {
        onClose(refresh)
        formik.resetForm()
    }

    return (
        <Dialog onClose={() => handleClose(false)} open={open} maxWidth="sm" fullWidth>
            <Typography variant="h4" p={1}>
                {isAdd ? 'Add employee' : 'Edit employee'}
            </Typography>
            <DialogContent>
                <Box
                    m={1}
                    pt={2}
                    sx={{ '& .MuiTextField-root': { my: 2 } }}
                    component="form"
                    onSubmit={formik.handleSubmit}
                    onReset={formik.handleReset}
                    noValidate
                >
                    {isAdd && <TextField
                        fullWidth
                        id="oib"
                        label="OIB"
                        type="text"
                        name="oib"
                        value={formik.values.oib}
                        onChange={formik.handleChange}
                        error={formik.touched.oib && Boolean(formik.errors.oib)}
                        helperText={formik.touched.oib && formik.errors.oib}
                    />}
                    <TextField
                        fullWidth
                        id="ime"
                        label="Ime"
                        type="text"
                        name="ime"
                        value={formik.values.ime}
                        onChange={formik.handleChange}
                        error={formik.touched.ime && Boolean(formik.errors.ime)}
                        helperText={formik.touched.ime && formik.errors.ime}
                    />
                    <TextField
                        fullWidth
                        id="prezime"
                        label="Prezime"
                        type="text"
                        name="prezime"
                        value={formik.values.prezime}
                        onChange={formik.handleChange}
                        error={formik.touched.prezime && Boolean(formik.errors.prezime)}
                        helperText={formik.touched.prezime && formik.errors.prezime}
                    />
                    <TextField
                        fullWidth
                        id="datumRodjenja"
                        label="Datum Rođenja"
                        type="text"
                        name="datumRodjenja"
                        value={formik.values.datumRodjenja}
                        onChange={formik.handleChange}
                        error={formik.touched.datumRodjenja && Boolean(formik.errors.datumRodjenja)}
                        helperText={formik.touched.datumRodjenja && formik.errors.datumRodjenja}
                    />
                    <FormControl sx={{ my: 2 }} fullWidth>
                        <InputLabel>Spol</InputLabel>
                        <Select
                            id="spol"
                            name="spol"
                            value={formik.values.spol}
                            label="spol"
                            onChange={formik.handleChange}
                        >
                            <MenuItem value="M">
                                M
                            </MenuItem>
                            <MenuItem value="Ž">
                                Ž
                            </MenuItem>
                        </Select>
                    </FormControl>
                    <TextField
                        fullWidth
                        id="datumZaposlenja"
                        label="Datum Zaposlenja"
                        type="text"
                        name="datumZaposlenja"
                        disabled={!isAdd ? true : false}
                        value={formik.values.datumZaposlenja}
                        onChange={formik.handleChange}
                        error={formik.touched.datumZaposlenja && Boolean(formik.errors.datumZaposlenja)}
                        helperText={formik.touched.datumZaposlenja && formik.errors.datumZaposlenja}
                    />
                    <TextField
                        fullWidth
                        id="email"
                        label="Email"
                        type="text"
                        name="email"
                        value={formik.values.email}
                        onChange={formik.handleChange}
                        error={formik.touched.email && Boolean(formik.errors.email)}
                        helperText={formik.touched.email && formik.errors.email}
                    />
                    <DialogActions>
                        <Button variant="contained" type="submit">
                            {isAdd ? 'Add' : 'Edit'}
                        </Button>
                        <Button onClick={() => handleClose(false)}>
                            Close
                        </Button>
                    </DialogActions>
                </Box>
            </DialogContent>
        </Dialog>
    )
}

export default AddEditEmpolyee;