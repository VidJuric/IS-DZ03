export interface Osoba {
    oib: string;
    ime: string;
    prezime: string;
    datumRodjenja: Date;
    spol: string;
    datumZaposlenja: Date;
    email: string;
}

export interface Employee extends Osoba {
    zaposlenikID: number;
}

export interface CustomerSupport extends Osoba {
    korisnickaSluzbaID: number;
}

export interface Zadatak {
    zadatakID: number;
    opis: string;
    zaposlenikID: number;
    korisnickasluzbaID: number;
    korisnickaSluzbaImePrezime: string;
    statusZadatkaID: number;
    uslugaID: number;
}

export interface ZadatakExtended extends Zadatak {
    statusZadatka: string;
    usluga: string;
}

export interface StatusZadatka {
    statusZadatkaID: number;
    opisStatusa: string;
}

export interface Usluga {
    uslugaID: number;
    opisUsluga: string;
    cijena: number;
}

export interface DropdownValues {
    id: number;
    value: string;
}

export interface DeleteInformation {
    id: number;
    name: string;
}