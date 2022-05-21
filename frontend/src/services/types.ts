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
    opis: string;
    zaposlenikID: number;
    korisnickaSluzbaID: number;
    statusZadatkaID: number;
    uslugaID: number;
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