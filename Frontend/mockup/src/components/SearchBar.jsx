import React from "react";
import { useState } from "react";
import { Autocomplete, Box, TextField, Grid } from "@mui/material";

// MOCK DATA VAN AUTOS
const top50cars = [
  { title: "Toyota Camry" },
  { title: "Honda Accord" },
  { title: "Tesla Model 3" },
  { title: "Ford Mustang" },
  { title: "Chevrolet Malibu" },
  { title: "BMW 3 Series" },
  { title: "Audi A4" },
  { title: "Mercedes-Benz C-Class" },
  { title: "Volkswagen Golf" },
  { title: "Nissan Altima" },
  { title: "Hyundai Sonata" },
  { title: "Kia Optima" },
  { title: "Subaru Impreza" },
  { title: "Mazda 6" },
  { title: "Dodge Charger" },
  { title: "Chrysler 300" },
  { title: "Jaguar XF" },
  { title: "Lexus IS" },
  { title: "Infiniti Q50" },
  { title: "Acura TLX" },
  { title: "Volvo S60" },
  { title: "Cadillac ATS" },
  { title: "Lincoln MKZ" },
  { title: "Buick Regal" },
  { title: "Alfa Romeo Giulia" },
  { title: "Genesis G70" },
  { title: "Porsche Panamera" },
  { title: "Maserati Ghibli" },
  { title: "Aston Martin Vantage" },
  { title: "Bentley Continental" },
  { title: "Rolls-Royce Ghost" },
  { title: "Ferrari 488" },
  { title: "Lamborghini Huracan" },
  { title: "McLaren 720S" },
  { title: "Pagani Huayra" },
  { title: "Bugatti Chiron" },
  { title: "Koenigsegg Agera" },
  { title: "Ford F-150" },
  { title: "Chevrolet Silverado" },
  { title: "Ram 1500" },
  { title: "Toyota Tundra" },
  { title: "Nissan Titan" },
  { title: "Honda Ridgeline" },
  { title: "GMC Sierra" },
  { title: "Jeep Grand Cherokee" },
  { title: "Land Rover Range Rover" },
  { title: "Toyota Land Cruiser" },
  { title: "Ford Explorer" },
  { title: "Chevrolet Tahoe" },
];

const SearchBar = () => {
  return (
    <Box display="flex" justifyContent="center" alignItems="center" mt={2}>
      <Box width="90%">
        <Grid container spacing={2}>
          <Grid item xs={12} sm={4}>
            <Autocomplete
              multiple
              id="model-search"
              options={top50cars}
              getOptionLabel={(option) => option.model}
              renderInput={(params) => (
                <TextField
                  {...params}
                  variant="standard"
                  label="Search by Model"
                  placeholder="Type here"
                />
              )}
            />
          </Grid>
          <Grid item xs={12} sm={4}>
            <Autocomplete
              multiple
              id="brand-search"
              options={top50cars}
              getOptionLabel={(option) => option.brand}
              renderInput={(params) => (
                <TextField
                  {...params}
                  variant="standard"
                  label="Search by Brand"
                  placeholder="Type here"
                />
              )}
            />
          </Grid>
          <Grid item xs={12} sm={4}>
            <Autocomplete
              multiple
              id="year-search"
              options={top50cars}
              getOptionLabel={(option) => option.year}
              renderInput={(params) => (
                <TextField
                  {...params}
                  variant="standard"
                  label="Search by Year"
                  placeholder="Type here"
                />
              )}
            />
          </Grid>
        </Grid>
      </Box>
    </Box>
  );
};

export default SearchBar;
