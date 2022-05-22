export interface Osoba {
    oib: string;
    ime: string;
    prezime: string;
    datumRodjenja: Date;
    spol: string;
    datumZaposlenja: Date;
    email: string;
}

export interface Zadatak {
    zadatakID: number;
    opis: string;
    zaposlenikID: number;
    korisnickasluzbaID: number;
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