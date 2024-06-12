import React from "react";
import { Autocomplete, Box, TextField, Grid } from "@mui/material";

// MOCK DATA VAN AUTOS
const top50cars = [
  { model: "Camry", brand: "Toyota", year: "2020", color: "Red" },
  { model: "Accord", brand: "Honda", year: "2019", color: "Blue" },
  { model: "Model 3", brand: "Tesla", year: "2021", color: "White" },
  { model: "Mustang", brand: "Ford", year: "2018", color: "Black" },
  { model: "Malibu", brand: "Chevrolet", year: "2017", color: "Grey" },
  { model: "3 Series", brand: "BMW", year: "2020", color: "Blue" },
  { model: "A4", brand: "Audi", year: "2019", color: "White" },
  { model: "C-Class", brand: "Mercedes-Benz", year: "2021", color: "Black" },
  { model: "Golf", brand: "Volkswagen", year: "2018", color: "Red" },
  { model: "Altima", brand: "Nissan", year: "2017", color: "Grey" },
  { model: "Sonata", brand: "Hyundai", year: "2020", color: "Silver" },
  { model: "Optima", brand: "Kia", year: "2019", color: "Blue" },
  { model: "Impreza", brand: "Subaru", year: "2021", color: "White" },
  { model: "Mazda 6", brand: "Mazda", year: "2018", color: "Black" },
  { model: "Charger", brand: "Dodge", year: "2017", color: "Red" },
  { model: "300", brand: "Chrysler", year: "2020", color: "Grey" },
  { model: "XF", brand: "Jaguar", year: "2019", color: "Blue" },
  { model: "IS", brand: "Lexus", year: "2021", color: "White" },
  { model: "Q50", brand: "Infiniti", year: "2018", color: "Black" },
  { model: "TLX", brand: "Acura", year: "2017", color: "Silver" },
  { model: "S60", brand: "Volvo", year: "2020", color: "Blue" },
  { model: "ATS", brand: "Cadillac", year: "2019", color: "White" },
  { model: "MKZ", brand: "Lincoln", year: "2021", color: "Black" },
  { model: "Regal", brand: "Buick", year: "2018", color: "Grey" },
  { model: "Giulia", brand: "Alfa Romeo", year: "2017", color: "Red" },
  { model: "G70", brand: "Genesis", year: "2020", color: "Blue" },
  { model: "Panamera", brand: "Porsche", year: "2019", color: "White" },
  { model: "Ghibli", brand: "Maserati", year: "2021", color: "Black" },
  { model: "Vantage", brand: "Aston Martin", year: "2018", color: "Grey" },
  { model: "Continental", brand: "Bentley", year: "2017", color: "Blue" },
  { model: "Ghost", brand: "Rolls-Royce", year: "2020", color: "White" },
  { model: "488", brand: "Ferrari", year: "2019", color: "Red" },
  { model: "Huracan", brand: "Lamborghini", year: "2021", color: "Green" },
  { model: "720S", brand: "McLaren", year: "2018", color: "Orange" },
  { model: "Huayra", brand: "Pagani", year: "2017", color: "Yellow" },
  { model: "Chiron", brand: "Bugatti", year: "2020", color: "Blue" },
  { model: "Agera", brand: "Koenigsegg", year: "2019", color: "Black" },
  { model: "F-150", brand: "Ford", year: "2021", color: "White" },
  { model: "Silverado", brand: "Chevrolet", year: "2018", color: "Black" },
  { model: "1500", brand: "Ram", year: "2017", color: "Red" },
  { model: "Tundra", brand: "Toyota", year: "2020", color: "Grey" },
  { model: "Titan", brand: "Nissan", year: "2019", color: "Blue" },
  { model: "Ridgeline", brand: "Honda", year: "2021", color: "White" },
  { model: "Sierra", brand: "GMC", year: "2018", color: "Black" },
  { model: "Grand Cherokee", brand: "Jeep", year: "2017", color: "Silver" },
  { model: "Range Rover", brand: "Land Rover", year: "2020", color: "Blue" },
  { model: "Land Cruiser", brand: "Toyota", year: "2019", color: "White" },
  { model: "Explorer", brand: "Ford", year: "2021", color: "Black" },
  { model: "Tahoe", brand: "Chevrolet", year: "2018", color: "Grey" },
];

const SearchBar = () => {
  return (
    <Box display="flex" justifyContent="center" alignItems="center" mt={2}>
      <Box width="90%">
        <Grid container spacing={2}>
          <Grid item xs={12} sm={3}>
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
          <Grid item xs={12} sm={3}>
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
          <Grid item xs={12} sm={3}>
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
          <Grid item xs={12} sm={3}>
            <Autocomplete
              multiple
              id="color-search"
              options={top50cars}
              getOptionLabel={(option) => option.color}
              renderInput={(params) => (
                <TextField
                  {...params}
                  variant="standard"
                  label="Search by Color"
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
