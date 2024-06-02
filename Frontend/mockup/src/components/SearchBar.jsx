// eslint-disable-next-line no-unused-vars
import React from "react";
import { Autocomplete, Box, TextField } from "@mui/material";

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
    <>
      <Box display="flex" justifyContent="center" alignItems="center">
        <Box width="50%">
          <Autocomplete
            multiple
            id="tags-standard"
            options={top50cars}
            getOptionLabel={(option) => option.title}
            renderInput={(params) => (
              <TextField
                {...params}
                variant="standard"
                label="Search for your desires"
                placeholder="Type here"
              />
            )}
          />
        </Box>
      </Box>
    </>
  );
};

export default SearchBar;
