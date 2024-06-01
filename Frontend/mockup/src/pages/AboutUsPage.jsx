import React from "react";
import { Box, Typography } from "@mui/material";

const AboutUsPage = () => {
  return (
    <Box
      display="flex"
      justifyContent="center"
      alignItems="center"
      minHeight="60vh"
      flexDirection="column"
      textAlign="center"
    >
      <Typography variant="h6" color="textSecondary">
        No insperation...
      </Typography>
      <Typography variant="body1" color="textSecondary">
        At least, this is where you can tell about you website/services.
      </Typography>
    </Box>
  );
};

export default AboutUsPage;
