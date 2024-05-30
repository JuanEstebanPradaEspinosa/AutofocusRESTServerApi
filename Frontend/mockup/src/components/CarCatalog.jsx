import React from "react";
import { MenuItem, Select, FormControl, InputLabel } from "@mui/material";

function CarCatalog({ cars, onSelectCar }) {
  return (
    <FormControl fullWidth>
      <InputLabel id="car-catalog-label">Catalogus</InputLabel>
      <Select
        labelId="car-catalog-label"
        id="car-catalog"
        value=""
        onChange={(e) => onSelectCar(e.target.value)}
      >
        {cars.map((car, index) => (
          <MenuItem key={index} value={car}>
            {car.brand} {car.model} ({car.year})
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
}

export default CarCatalog;
